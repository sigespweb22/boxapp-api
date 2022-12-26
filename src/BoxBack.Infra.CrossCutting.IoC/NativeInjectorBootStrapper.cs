using Microsoft.Extensions.DependencyInjection;
using BoxBack.Infra.Data.UoW;
using BoxBack.Domain.InterfacesNoSQL;
using BoxBack.Infra.Data.RepositoryNoSQL;
using BoxBack.Application.Interfaces;
using BoxBack.Infra.CrossCutting.Identity.Services;
using BoxBack.Application.AppServices;
using Sigesp.Domain.InterfacesRepositories;
using Sigesp.Infra.Data.Repository;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Services;

namespace BoxBack.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // AppServices
            services.AddScoped<IClienteAppService, ClienteAppService>();

            // Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IRotinaEventHistoryService, RotinaEventHistoryService>();

            // Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IRotinaEventHistoryRepository, RotinaEventHistoryRepository>();

            // Transient: Created each time.
            // Scoped: Created only once per request.
            // Singleton: Created the first time they are requested. Each subsequent request uses the instance that was created the first time.

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repo NoSQL
            services.AddTransient<IClienteRepositoryNoSQL, ClienteRepositoryNoSQL>();

            // Application
            services.AddScoped<INavigationAppService, NavigationAppService>();

            services.AddScoped<UserResolverService>();
            services.AddScoped<ValidationResult>();            
        }
    }
}