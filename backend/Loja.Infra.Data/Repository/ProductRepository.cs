using Loja.Domain.Entities;
using Loja.Domain.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(LojaDbContext context) : base(context)
        {
            
        }

        
    }
}
