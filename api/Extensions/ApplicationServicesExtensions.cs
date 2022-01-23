
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.Extensions
{
    public static class ApplicationServicesExtensions
    {
       public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) {
           services.AddDbContext<DataContext>(options => {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ITokenService, TokenService>();
            // services.AddTransient<Seed>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
       }
    }
}