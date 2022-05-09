using Loja.Domain.Entities;
using Loja.Domain.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Data.Repository
{
    public class ClientRepository : RepositoryBase<Clients>, IClientRepository
    {
        public ClientRepository(LojaDbContext context) : base(context)
        {
            
        }

        
    }
}
