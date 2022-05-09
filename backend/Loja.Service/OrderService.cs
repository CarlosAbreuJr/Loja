using AutoMapper;
using Loja.Domain.Entities;
using Loja.Domain.Enuns;
using Loja.Domain.Interface.External;
using Loja.Domain.Interface.Repositories;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Loja.Domain.Models.External;
using Loja.Uteis;

namespace Loja.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IMessage _message;
        public OrderService(IOrderRepository orderRepository, IMapper mapper, IMessage message)
        {
            _orderRepository=orderRepository;
            _mapper=mapper;
            _message=message;
        }

        public void Add(OrderModel model)
        {
            var order = _mapper.Map<Order>(model);
            _orderRepository.Add(order);    
        }

        public void CancelPurchase(int id)
        {
            _orderRepository.CancelPurchase(id);

        }

        public async  Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAsync();

            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async void Update(UpdateOrderModel model)
        {
            var orderReceived = _mapper.Map<Order>(model);
            var order = await _orderRepository.GetAsync(model.Id);
            if (order != null)
                throw new ArgumentException("Pedido não encontrado");
            
            throw new NotImplementedException();
            
        }
    }
}