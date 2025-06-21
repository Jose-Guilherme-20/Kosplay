using Kosplay.API.Servicos;
using Kosplay.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Kosplay.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Serviços de aplicação
            services.AddScoped<IAuthService, AuthService>();

            // Repositórios
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();


            return services;
        }
    }
}
