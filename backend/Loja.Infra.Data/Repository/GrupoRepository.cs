using Loja.Domain.Entities;
using Loja.Domain.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Data.Repository
{
    public class GrupoRepository : RepositoryBase<Grupos>, IGrupoRepository
    {
        public GrupoRepository(LojaDbContext context) : base(context)
        {
            
        }

        
    }
}
