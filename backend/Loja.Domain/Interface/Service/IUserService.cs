using Loja.Domain.Entities;
using Loja.Domain.Enuns;
using Loja.Domain.Models;
using Loja.Domain.Models.Shared;
using Loja.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        void Add(CreateUserModel model);
        Task<UserLoginReponse> LoginAsync(LoginUserModel model);
        Task<ResponseBase<IEnumerable<String>>> ResetPasswordAsync(ResetPasswordModel model);
        Task<ResponseBase<IEnumerable<String>>> UpdatePasswordAsync(ChangePasswordModel model);
        Task<CreateUserResponse> CreateUserAsync(CreateUserModel user, params ApplicationRole[] userRoles);
        Task<User> FindByEmailAsync(string email);
        Task<CreateUserResponse> CreateUserAsync(CreateUserNoPassModel userModel, params ApplicationRole[] userRoles);
        Task<UserModel> GetByEmailAsync(string email);
    }
}
