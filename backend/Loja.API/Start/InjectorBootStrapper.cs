using Loja.Domain.Interface.External;
using Loja.Domain.Interface.Repositories;
using Loja.Domain.Interface.Service;
using Loja.Infra.Data.Repository;
using Loja.Service;
using Loja.Service.External;
using Loja.Uteis;
using Loja.Uteis.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.API.Start
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IGrupoService, GrupoService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenHandler, TokenHandler>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
           
            services.AddScoped<IMessage, SentMessage>();



        }
    }
}
