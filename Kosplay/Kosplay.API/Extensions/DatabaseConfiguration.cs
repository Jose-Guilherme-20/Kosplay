using Kosplay.Domain.Models.Entity;
using Kosplay.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kosplay.API.Extensions
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection ConfigurationDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionDefault")));

            return services;
        }
    }
}
