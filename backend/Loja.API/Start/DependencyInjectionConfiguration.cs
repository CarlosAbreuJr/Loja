using Microsoft.Extensions.DependencyInjection;

namespace Loja.API.Start
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            InjectorBootStrapper.RegisterServices(services);

            MapperRegistry.Load(services);
        }
    }
}
