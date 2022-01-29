
using api.Data;
using api.Seeding;
using api.Helpers;
using api.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using api.Implementations;
using api.interfaces.reports;
using api.Implementations.reports;
using api.Interfaces.statistics;
using api.Implementations.statistics;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            /*   services.AddDbContext<DataContext>(options => {
                   options.UseSqlite(config.GetConnectionString("DefaultConnection"));
               }); */

            var _connectionString = config.GetConnectionString("SQLConnection");
            services.AddDbContext<DataContext>(
                options => options.UseMySql(
                    _connectionString,
                    ServerVersion.AutoDetect(_connectionString)
                )
            );
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

            /*          services.AddDbContext<DataContext>(options => options
                       .UseMySql(config.GetConnectionString("SQLConnection"),
                           mysqlOptions =>
                               mysqlOptions.ServerVersion(new Pomelo.EntityFrameworkCore.MySql.Storage.ServerVersion(new Version(10, 4, 6), ServerType.MariaDb)).EnableRetryOnFailure()));
        */




            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IValveRepository, ValveRepository>();
            services.AddScoped<IProcedureRepository, ProcedureRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ILtxRepository, LtxRepository>();

            services.AddScoped<IPV, PV>();
            services.AddScoped<IAorticSurgery, AorticSurgery>();
            services.AddScoped<IMinInv, MinInv>();
            services.AddScoped<ICABGRepository, CABGRepository>();
            services.AddScoped<ICPBRepository, CPBRepository>();
            services.AddScoped<IPORepository, PORepository>();
            services.AddScoped<IDischarge, Discharge>();
            services.AddScoped<IMinInv, MinInv>();
            services.AddScoped<IRefPhys, RefPhys>();
            services.AddScoped<ISuggestion, Suggestion>();
            services.AddScoped<IComposeFinalReport, ComposeFinalReport>();


            services.AddScoped<IStatistics, Statistics>();
            services.AddScoped<IElementaryStatistics, ElementaryStatistics>();
            services.AddScoped<IInstitutionalText, InstitutionalText>();
            services.AddScoped<IAioRepo, AioRepo>();

            services.AddScoped<OperatieDrops>();
            services.AddScoped<SpecialMaps>();
            services.AddScoped<SpecialReportMaps>();
            services.AddScoped<LogUserActivity>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }
    }
}