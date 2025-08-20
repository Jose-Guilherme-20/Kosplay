using Kosplay.API.Servicos;
using Kosplay.Domain.Interfaces.HttpService;
using Kosplay.Domain.Interfaces.Services;
using Kosplay.Infra.Services;
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

            #region INFRA
            services.AddScoped<IImageKitService, ImageKitService>();
            #endregion

            return services;
        }
    }
}
