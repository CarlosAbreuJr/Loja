using AutoMapper;
using Loja.Domain.Entities;
using Loja.Domain.Enuns;
using Loja.Domain.Interface.External;
using Loja.Domain.Interface.Repositories;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Loja.Domain.Models.External;
using Loja.Domain.Models.Shared;
using Loja.Domain.Models.User;
using Loja.Uteis;
using Loja.Uteis.Interfaces;

namespace Loja.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMessage _message;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(IUserRepository userRepository, IMapper mapper, IMessage message, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _userRepository=  userRepository;
            _mapper= mapper;
            _message= message;
            _unitOfWork=unitOfWork;
            _passwordHasher=passwordHasher;
        }

        public void Add(CreateUserModel model)
        {
            var user = _mapper.Map<User>(model);

            user.Password = _passwordHasher.HashPassword(model.Password);
            user.EmailIsValid = false;
            user.Role = "Customer";
            _userRepository.AddAsync(user);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await _userRepository.GetAsync();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public async Task<UserLoginReponse> LoginAsync(LoginUserModel model)
        {
            throw new NotImplementedException("Requer refatoração, Utilizar v2");
            var password = _passwordHasher.HashPassword(model.Password);
            var user = await _userRepository.GetUserValidationAsync(model.Username, password);
            if (user == null)
            {
                return new UserLoginReponse
                {
                    UserStatus = (int)EnumStatusUser.InvalidUserPass,
                    Messagem = "Usuário ou senha inválido"
                };
            }

            if (!user.EmailIsValid && user.CreateIn.AddDays(2) < DateTime.Now)
            {
                return new UserLoginReponse
                {
                    UserStatus = (int)EnumStatusUser.ConfirmEmail,
                    Messagem = "Email não confirmado, por favor, confirme seu email para continuar"
                };
            }

            if (user.IsChangePassword)
            {
                return new UserLoginReponse
                {
                    UserStatus = (int)EnumStatusUser.ResetPassword,
                    Messagem = "Senha temporária, atualize sua senha!"
                };
            }

            return _mapper.Map<UserLoginReponse>(user);
        }

        public async Task<ResponseBase<IEnumerable<String>>> ResetPasswordAsync(ResetPasswordModel model)
        {
            var user = await _userRepository.FindByEmailOrUserAsync(model.Email, model.Username);

            if (user == null || model.Document != user.Documento)
            {
                return new ResponseBase<IEnumerable<String>>(false, new List<string> {
                    "Dados não conferem, verifique e tente novamente"
                });
            }

            var newPass = PasswordGenerate.New();
            var criptPass = _passwordHasher.HashPassword(newPass);
            user.IsChangePassword = true;
            user.PasswordTmp = criptPass;
            user.Password = criptPass;
            user.ChangeIn = DateTime.Now;
            _userRepository.Update(user);

            return new ResponseBase<IEnumerable<String>>(true, PassTempNotification(newPass, user, model.NotificationType));
        }

        //public async Task<IEnumerable<string>> UpdatePasswordAsync(ChangePasswordModel model)
        public async Task<ResponseBase<IEnumerable<String>>> UpdatePasswordAsync(ChangePasswordModel model)
        {
            var user = await _userRepository.FindByEmailAsync(model.Email);

            if (user == null || !_passwordHasher.PasswordMatches(model.OldPassword, user.Password))
            {
                return new ResponseBase<IEnumerable<string>>(false, new List<string>
                {
                    "Dados não conferem, verifique e tente novamente"
                });
            }

            var criptPass = _passwordHasher.HashPassword(model.NewPassword);
            user.IsChangePassword = false;
            user.PasswordTmp = null;
            user.Password = criptPass;
            user.ChangeIn = DateTime.Now;
            _userRepository.Update(user);

            return new ResponseBase<IEnumerable<string>>(true, new List<string> { "Senha atualizada com sucesso" });
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserModel userModel, params ApplicationRole[] userRoles)
        {
            //V2
            var existingUser = await _userRepository.FindByEmailAsync(userModel.Email);
            if (existingUser != null)
            {
                return new CreateUserResponse(false, "Email already in use.", null);
            }

            userModel.Password = _passwordHasher.HashPassword(userModel.Password);

            var userAdd = _mapper.Map<User>(userModel);
            await _userRepository.AddAsync(userAdd, userRoles);

            var user = await _userRepository.FindByEmailAsync(userModel.Email);
            var userResult = _mapper.Map<User, CreateUserNoPassModel>(user);

            return new CreateUserResponse(true, userResult);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserNoPassModel userModel, params ApplicationRole[] userRoles)
        {
            //V3
            var existingUser = await _userRepository.FindByEmailAsync(userModel.Email);
            if (existingUser != null)
            {
                return new CreateUserResponse(false, "Email already in use.", null);
            }
            var userAdd = _mapper.Map<User>(userModel);

            var newPass = PasswordGenerate.New();
            var criptoPass = _passwordHasher.HashPassword(newPass);
            userAdd.Password = criptoPass;
            userAdd.PasswordTmp = criptoPass;
            userAdd.CreateIn = DateTime.Now;
            userAdd.EmailIsValid = false;
            userAdd.IsChangePassword = true;
            await _userRepository.AddAsync(userAdd, userRoles);

            var user = await _userRepository.FindByEmailAsync(userModel.Email);
            var userResult = _mapper.Map<User, CreateUserNoPassModel>(user);

            var feed = PassTempNotification(newPass, user, userModel.NotificationType);

            return await Task.FromResult<CreateUserResponse>(new CreateUserResponse(true, feed, userResult));
        }

        private IEnumerable<string> PassTempNotification(string newPass, User user, EnumNotificationType notificationType)
        {
            List<string> resetMessage = new List<string>();

            var sms = new MessageSmsModel
            {
                Conteudo = "Senha Temporária - Cadastro Loja: " + newPass,
                CelularDestino = user.Celular
            };

            var email = new MessageEmailModel
            {
                Assunto = $"Senha Temporária - Cadastro Loja:  - {user.Name}",
                Conteudo = $"Senha temporária é: <b>{newPass}</b>",
                EmailDestinatario = user.Email,
                Remetente = "carlosabreujr@gmail.com"
            };

            Notification(notificationType, email, sms);

            var mailSpl = user.Email.Split('@');
            resetMessage.Add("Email enviado para: ******" + mailSpl[0].Substring((mailSpl[0].Length - 4), 4) + "@" + mailSpl[1]);
            resetMessage.Add("Sms enviado para :"+ user.Celular.Substring(0, 4) + "******" + user.Celular.Substring((user.Celular.Length - 4), 4));


            return resetMessage;
        }
        private void Notification(EnumNotificationType notificationType, MessageEmailModel emailModel, MessageSmsModel smsModel = null)
        {
            if (notificationType == EnumNotificationType.Email || notificationType == EnumNotificationType.SmsAndEmail)
                _message.EMAIL(emailModel);

            if (notificationType == EnumNotificationType.Sms || notificationType == EnumNotificationType.SmsAndEmail)
                _message.SMS(smsModel);
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            var user =  await _userRepository.FindByEmailAsync(email);

            return _mapper.Map<UserModel>(user);
        }

    }
}