using Kosplay.API.Servicos;
using Kosplay.Domain.Interfaces.HttpService;
using Kosplay.Domain.Interfaces.Services;
using Kosplay.Infra.Services;
using Microsoft.EntityFrameworkCore;

namespace Kosplay.API.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Serviços de aplicação
            services.AddScoped<IAuthService, AuthService>();  

            return services;
        }
    }
}
