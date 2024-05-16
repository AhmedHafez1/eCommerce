using Core.Entities.Identity;
using Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

            services.AddIdentityCore<AppUser>(opt =>
            {
                // Configure identity options if needed
            }).AddEntityFrameworkStores<AppIdentityContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }
    }
}
