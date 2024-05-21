using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Errors;
using System.Net;
using StackExchange.Redis;
using Infrastructure.Services;

namespace API.Extension_Methods
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("Default"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                    .Where(k => k.Value!.Errors.Any())
                    .SelectMany(key => key.Value!.Errors)
                    .Select(e => e.ErrorMessage);

                    var errorResponse = new ErrorResponse((int)HttpStatusCode.BadRequest, null!, null, errors);
                    return new NotFoundObjectResult(errorResponse);
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var options = ConfigurationOptions.Parse(config.GetConnectionString("Redis")!);
                return ConnectionMultiplexer.Connect(options);
            });

            return services;
        }
    }
}
