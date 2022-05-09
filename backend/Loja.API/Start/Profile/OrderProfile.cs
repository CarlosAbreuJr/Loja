using AutoMapper;
using Loja.Domain.Models;
using Loja.Domain.Entities;

namespace Loja.API.Start.Profiles
{
    public class OrderProfile : Profile
    {

        public OrderProfile()
        {
            CreateMap<Order, OrderModel>()
                .ReverseMap();

            CreateMap<Order, UpdateOrderModel>()
    .ReverseMap();

        }
    }
}