
using Kosplay.Domain.Interfaces.HttpService;
using Kosplay.Domain.Interfaces.Repository;
using Kosplay.Domain.Interfaces.UnitOfWork;
using Kosplay.Domain.Models.HttpService;
using Kosplay.Infra.Context;
using Kosplay.Infra.Repository;
using Kosplay.Infra.Services;
using Kosplay.Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kosplay.Infra
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            ConfigurationDatabase(services, configuration);

            // Register Repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            #region INFRA
            services.AddScoped<IImageKitService, ImageKitService>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
            #endregion

            return services;
        }

        private static IServiceCollection ConfigurationDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KosplayDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionDefault")));

            return services;
        }
    }
}
