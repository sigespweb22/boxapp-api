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
            services.AddScoped<IChaveApiTerceiroAppService, ChaveApiTerceiroAppService>();
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IClienteContratoAppService, ClienteContratoAppService>();
            services.AddScoped<IRotinaAppService, RotinaAppService>();
            services.AddScoped<IRotinaEventHistoryAppService, RotinaEventHistoryAppService>();
            services.AddScoped<IClienteContratoFaturaAppService, ClienteContratoFaturaAppService>();
            services.AddScoped<IVendedorComissaoAppService, VendedorComissaoAppService>();
            services.AddScoped<IVendedorContratoAppService, VendedorContratoAppService>();

            // Services
            services.AddScoped<IChaveApiTerceiroService, ChaveApiTerceiroService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteContratoService, ClienteContratoService>();
            services.AddScoped<IRotinaService, RotinaService>();   
            services.AddScoped<IRotinaEventHistoryService, RotinaEventHistoryService>();
            services.AddScoped<IClienteContratoFaturaService, ClienteContratoFaturaService>();
            services.AddScoped<IVendedorComissaoService,VendedorComissaoService>();
            services.AddScoped<IVendedorContratoService,VendedorContratoService>();

            // Repositories
            services.AddScoped<IChaveApiTerceiroRepository, ChaveApiTerceiroRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteContratoRepository, ClienteContratoRepository>();
            services.AddScoped<IRotinaEventHistoryRepository, RotinaEventHistoryRepository>();
            services.AddScoped<IRotinaRepository, RotinaRepository>();
            services.AddScoped<IClienteContratoFaturaRepository, ClienteContratoFaturaRepository>();
            services.AddScoped<IVendedorComissaoRepository, VendedorComissaoRepository>();
            services.AddScoped<IVendedorContratoRepository, VendedorContratoRepository>();

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