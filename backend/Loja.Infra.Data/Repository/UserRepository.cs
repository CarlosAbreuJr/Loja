using Loja.Domain.Entities;
using Loja.Domain.Enuns;
using Loja.Domain.Interface.Repositories;
using Loja.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Infra.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(LojaDbContext context) : base(context)
        {
            
        }

        public async Task<User> GetUserValidationAsync(string username, string password)
        {
            var user = await GetAsync(x => x.Username ==username && x.Password ==password);
            return user.FirstOrDefault();
        }

        public async Task<User> GetAsync(string username, string email, string document) 
        {
           var users = await GetAsync(x => (x.Username == username || x.Email == email) && x.Documento == document);
            return users.FirstOrDefault();
        }

        public async Task<User> GetUserValidationAsync(string username, string email, string password)
        {
            var user = await GetAsync(x => (x.Username ==username || x.Email == email) && x.Password ==password);
            return user.FirstOrDefault();
        }

        public async Task AddAsync(User user, ApplicationRole[] userRoles)
        {
            var roleNames = userRoles.Select(r => r.ToString()).ToList();
            var roles = await _context.Set<Role>().Where(r => roleNames.Contains(r.Name)).ToListAsync();

            foreach (var role in roles)
            {
                user.UserRoles.Add(new UserRole { RoleId = role.Id });
            }
            await AddAsync(user);
            //_context.Users.Add(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Set<User>().Include(u => u.UserRoles)
                                        .ThenInclude(ur => ur.Role)
                                        .SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> FindByEmailOrUserAsync(string email, string username)
        {
            return await _context.Set<User>().Include(u => u.UserRoles)
                                        .ThenInclude(ur => ur.Role)
                                        .SingleOrDefaultAsync(u => u.Email == email || u.Username == username);
        }
    }
}
