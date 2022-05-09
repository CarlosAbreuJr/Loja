using Loja.Domain.Entities;
using Loja.Domain.Enuns;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserValidationAsync(string username, string password);
        Task<User> GetUserValidationAsync(string username, string email, string password);
        Task<User> GetAsync(string username, string email, string document);
        //---
        Task AddAsync(User user, ApplicationRole[] userRoles);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByEmailOrUserAsync(string email, string username);
    }
}
