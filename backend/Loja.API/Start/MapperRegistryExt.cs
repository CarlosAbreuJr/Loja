using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.API.Start
{
    public class MapperRegistry
    {
        public static void Load(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationProvider>((c) => AutoMapperConfiguration.Configure());
            services.AddSingleton((c) => AutoMapperConfiguration.RegisterMappings());
        }
    }
}
