
using api.Data;
using api.Seeding;
using api.Helpers;
using api.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using api.Implementations;

namespace api.Extensions
{
    public static class ApplicationServicesExtensions
    {
       public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) {
           services.AddDbContext<DataContext>(options => {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();

            services.AddTransient<Seed>();
            services.AddTransient<SpecialMaps>();
            services.AddTransient<SpecialReportMaps>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
       }
    }
}