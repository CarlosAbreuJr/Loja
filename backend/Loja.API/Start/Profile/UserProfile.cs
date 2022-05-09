using AutoMapper;
using Loja.Domain.Models;
using Loja.Domain.Entities;
using Loja.API.Resources;
using Loja.Domain.Models.Authentication;

namespace Loja.API.Start.Profiles
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();
            CreateMap<User, CreateUserModel>()
                .ReverseMap();
            CreateMap<User, LoginUserModel>()
                .ReverseMap();
            CreateMap<User, UserLoginReponse>()
              .ReverseMap();
            CreateMap<User, CreateUserNoPassModel>()
              .ReverseMap();
            CreateMap<TokenResponse, AccessTokenResource>();
            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(dest=> dest.AccessToken, opt => opt.MapFrom(scr => scr.Token))
                .ForMember(dest=> dest.RefreshToken, opt => opt.MapFrom(scr => scr.RefreshToken.Token))
                .ReverseMap();
        }
    }
}