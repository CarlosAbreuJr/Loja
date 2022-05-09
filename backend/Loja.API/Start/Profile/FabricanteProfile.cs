using AutoMapper;
using Loja.Domain.Models;
using Loja.Domain.Entities;

namespace Loja.API.Start.Profiles
{
    public class FabricanteProfile : Profile
    {

        public FabricanteProfile()
        {
            CreateMap<Fabricantes, FabricanteModel>()
                .ReverseMap();

        }
    }
}