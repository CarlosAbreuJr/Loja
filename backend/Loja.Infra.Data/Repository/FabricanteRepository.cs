using Loja.Domain.Entities;
using Loja.Domain.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Data.Repository
{
    public class FabricanteRepository : RepositoryBase<Fabricantes>, IFabricanteRepository
    {
        public FabricanteRepository(LojaDbContext context) : base(context)
        {
            
        }

        
    }
}
