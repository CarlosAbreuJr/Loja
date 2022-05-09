using AutoMapper;
using Loja.Domain.Models;
using Loja.Domain.Entities;

namespace Loja.API.Start.Profiles
{
    public class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<Product, ProductModel>()
                .ReverseMap();

        }
    }
}