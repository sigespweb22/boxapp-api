using BoxBack.Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using BoxBack.Domain.Models;
using BoxBack.Domain.Enums;

namespace BoxBack.WebApi.StartupExtensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddDbContext<BoxAppDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                
                // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                if (!env.IsProduction())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging(true);
                }
            });

            return services;
        }
    }
}
