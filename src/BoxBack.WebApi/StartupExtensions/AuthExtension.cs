using System;
using System.Text;
using BoxBack.Infra.Data.Context;
using BoxBack.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BoxBack.WebApi.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace BoxBack.WebApi.StartupExtensions
{
    public static class AuthExtension
    {
        public static IServiceCollection AddCustomizedAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddEntityFrameworkStores<BoxAppDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;
            });

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy("MASTER", policy => policy.RequireClaim("BoxAppApi", "MASTER"));
            //     options.AddPolicy("CLIENTE_ALL", policy => policy.RequireClaim("BoxAppApi", "MASTER", "CLIENTE_ALL"));
            //     options.AddPolicy("CLIENTE_ADD", policy => policy.RequireClaim("BoxAppApi", "MASTER", "CLIENTE_ADD"));
            //     options.AddPolicy("CLIENTE_REMOVE", policy => policy.RequireClaim("BoxAppApi", "MASTER", "CLIENTE_REMOVE"));
            // });

            return services;
        }

        public static IApplicationBuilder UseCustomizedAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
