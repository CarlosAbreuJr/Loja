using AutoMapper;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Loja.Domain.Models.Authentication;
using Loja.Uteis.Interfaces;

namespace Loja.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;
        public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher, ITokenHandler tokenHandler, IMapper mapper)
        {
            _tokenHandler = tokenHandler;
            _passwordHasher = passwordHasher;
            _userService = userService;
            _mapper=mapper;
        }

        public async Task<TokenResponse> CreateAccessTokenAsync(string email, string password)
        {
            var user = await _userService.FindByEmailAsync(email);
            
            if (user == null || !_passwordHasher.PasswordMatches(password, user.Password))
            {
                return new TokenResponse(false, new LoginResponse {
                                                        Message = "Credencial inválida", 
                                                        UserStatus = Domain.Enuns.EnumStatusUser.InvalidUserPass 
                });
            }

            if (!user.EmailIsValid && user.CreateIn.AddDays(2) < DateTime.Now)
            {
                return new TokenResponse(false, new LoginResponse
                {
                    Message = "Email não confirmado, por favor, confirme seu email para continuar",
                    UserStatus = Domain.Enuns.EnumStatusUser.ConfirmEmail
                });
            }

            if (user.IsChangePassword)
            {
                return new TokenResponse(false, new LoginResponse
                {
                    Message = "Senha temporária, atualize sua senha!",
                    UserStatus = Domain.Enuns.EnumStatusUser.ResetPassword
                });
            }

            var token = _tokenHandler.CreateAccessToken(user);

            return new TokenResponse(true, new LoginResponse{ 
                                        Token= _mapper.Map<AccessTokenResource>(token), 
                                        UserStatus = Domain.Enuns.EnumStatusUser.Ok, 
                                        Message = "Usuário validado com sucesso!" 
            });
        }

        public async Task<AccessToken> RefreshTokenAsync(string refreshToken, string userEmail)
        {
            var token = _tokenHandler.TakeRefreshToken(refreshToken);

            if (token == null)
            {
                throw new ArgumentException("Invalid refresh token.");
            }

            if (token.IsExpired())
            {
                throw new ArgumentException("Expired refresh token.");
            }

            var user = await _userService.FindByEmailAsync(userEmail);
            if (user == null)
            {
                throw new ArgumentException("Invalid refresh token.");
            }

            var accessToken = _tokenHandler.CreateAccessToken(user);
            return accessToken;
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            _tokenHandler.RevokeRefreshToken(refreshToken);
        }
    }

}
