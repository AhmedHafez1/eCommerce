using Core.Entities.Identity;
using Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            services.AddAuthentication()
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"]!)),
                        ValidateIssuer = true,
                        ValidIssuer = config["Token:Issuer"]
                    };
                });
            services.AddAuthorization();

            return services;
        }
    }
}
