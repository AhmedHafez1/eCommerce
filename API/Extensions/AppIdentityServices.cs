using Infrastructure.Data.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class AppIdentityServices
    {
        public static IServiceCollection AddAppIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppIdentityContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("Identity"));
            });

            return services;
        }
    }
}
