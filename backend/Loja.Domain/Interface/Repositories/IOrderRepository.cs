using Loja.Domain.Entities;
using Loja.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Add(Order model);

        void CancelPurchase(int id);
    }
}
