using Loja.Domain.Entities;
using Loja.Domain.Interface.Repositories;
using Loja.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Infra.Data.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(LojaDbContext context) : base(context)
        {
            
        }

        public void Add(Order model)
        {
            _context.Set<Order>().Add(model);
            _context.SaveChanges();
        }

        public async void CancelPurchase(int id)
        {
            var order =await GetAsync(id);
            Remove(order);
        }
    }
}
