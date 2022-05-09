using AutoMapper;
using Loja.Domain.Models;
using Loja.Domain.Entities;

namespace Loja.API.Start.Profiles
{
    public class GrupoProfile : Profile
    {

        public GrupoProfile()
        {
            CreateMap<Grupos, GrupoModel>()
                .ReverseMap();

        }
    }
}