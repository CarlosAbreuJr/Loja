using AutoMapper;
using Loja.Domain.Models;
using Loja.Domain.Entities;

namespace Loja.API.Start.Profiles
{
    public class ClientProfile : Profile
    {

        public ClientProfile()
        {
            CreateMap<Clients, ClientModel>()
                .ReverseMap();

        }
    }
}