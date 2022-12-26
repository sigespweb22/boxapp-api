using Microsoft.Extensions.DependencyInjection;
using BoxBack.Infra.Data.UoW;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.InterfacesNoSQL;
using BoxBack.Infra.Data.RepositoryNoSQL;
using BoxBack.Application.Interfaces;
using BoxBack.Infra.CrossCutting.Identity.Services;
using BoxBack.Application.AppServices;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Repository;

namespace BoxBack.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Services
            services.AddScoped<IClienteAppService, ClienteAppService>();

            // Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();

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