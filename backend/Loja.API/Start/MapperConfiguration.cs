using AutoMapper;
using Loja.API.Start.Profiles;

namespace Loja.API.Start
{
    public class AutoMapperConfiguration
    {
        public static IMapper RegisterMappings()
        {
            MapperConfiguration config = Configure();

            return config.CreateMapper();
        }

        public static MapperConfiguration Configure()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;

                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<GrupoProfile>();
                cfg.AddProfile<FabricanteProfile>();
                cfg.AddProfile<ClientProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<OrderProfile>();

            });

            return config;
        }
    }
}