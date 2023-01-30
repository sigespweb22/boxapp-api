using System;
using System.IO;
using System.Reflection;
using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BoxBack.WebApi.StartupExtensions;
using Microsoft.AspNetCore.Authorization;
using BoxBack.Infra.CrossCutting.IoC;
using Microsoft.Extensions.Logging;
using Dapper;
using BoxBack.WebApi.Helpers;
using BoxBack.WebApi.Security;
using BoxBack.Domain.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using BoxBack.Domain.Hubs;
using BoxBack.WebApi.ScheduleServices;

namespace BoxBack.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        private IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public void ConfigureServices(IServiceCollection services)
        {           
            services.Configure<CookiePolicyOptions>(options =>
            {
                // Este lambda determina se o consentimento do usuário para cookies não essenciais é necessário para uma determinada solicitação.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // ----- Database -----
            services.AddCustomizedDatabase(Configuration, _env);

            // ----- AutoMapper -----
            services.AddAutoMapperSetup();

            // services.AddTransient<IEmailSender, EmailSender>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //In-Memory
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });              

            services.AddLogging(loggingBuilder => {
                loggingBuilder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
                loggingBuilder.AddDebug();
            });

            services.AddCors(options => 
            { 
                options.AddPolicy("ClientPermission", policy => 
                { policy.AllowAnyHeader( 
                    ) 
                        .AllowAnyMethod() 
                        .WithOrigins("http://localhost:3000", "http://boxapp.boxtecnologia.com.br")
                        .WithOrigins("http://boxapp.boxtecnologia.com.br:3000", "http://boxapp.boxtecnologia.com.br/")
                        .AllowCredentials(); 
                }); 
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            // ----- Api Version -----
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                        o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // ----- Swagger -----
            services.AddSwaggerGen(c => 
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Version = "v1",
                    Title = "BoxApp API",
                    Description = "Api BoxApp",
                    TermsOfService = new Uri("https://www.boxtecnologia.com.br/terms-service"),
                    Contact = new OpenApiContact
                    {
                        Name = "Box Tecnologia",
                        Url = new Uri("https://www.boxtecnologia.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Box Tecnologia License",
                        Url = new Uri("https://www.boxtecnologia.com.br/license")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });

            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.Converters.Add(new CustomJsonConverterForTypeExtensions());
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString 
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.DatabaseName 
                    = Configuration.GetSection("MongoConnection:DatabaseName").Value;
            });

            // ----- Auth -----
            services.AddCustomizedAuth(Configuration);

            // ----- Http -----
            services.AddCustomizedHttp(Configuration);

            // ----- SignalR - WebSocket -----
            services.AddSignalR();

            // ----- Scheduler Services -----
            // services.AddHostedService<RotinaScheduleService>();

            services.AddScoped<GeneratorToken>();

            // .NET Native DI Abstraction
            RegisterServices(services);

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(err => err.UseCustomErrors(env));
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            var supportedCultures = new[] { "pt-BR" };
            var localizationOptions = new RequestLocalizationOptions()
                                            .SetDefaultCulture(supportedCultures[0])
                                            .AddSupportedCultures(supportedCultures)
                                            .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            app.UseHttpsRedirection();
            app.UseRouting();

            // ----- Auth -----
            app.UseCustomizedAuth();

            app.UseCors("ClientPermission");
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificacaoHub>("/notificacaoHub");
            });
        }

        private class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
        {
            public override void SetValue(IDbDataParameter parameter, Guid value) => parameter.Value = value;

            public override Guid Parse(object value) => Guid.Parse((string) value);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}