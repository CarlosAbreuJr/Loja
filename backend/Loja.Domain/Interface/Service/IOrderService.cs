using Loja.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetAllAsync();
        void Add(OrderModel model);
        void Update(UpdateOrderModel model);
        void CancelPurchase(int id);
     
    }
}
