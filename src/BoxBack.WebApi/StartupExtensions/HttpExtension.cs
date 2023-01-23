using System;
using BoxBack.Domain.ServicesThirdParty;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;

namespace BoxBack.WebApi.StartupExtensions
{
    public static class HttpExtension
    {
        public static IServiceCollection AddCustomizedHttp(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpClient("IBGE_ESTADOS_API", c =>
                {
                    c.BaseAddress = new Uri(configuration.GetValue<string>("HttpClients:IBGE_ESTADOS_API"));
                })
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)))
                .AddTypedClient(c => Refit.RestService.For<IIBGEServices>(c));
            
            services
                .AddHttpClient("ESTADOS_API", c =>
                {
                    c.BaseAddress = new Uri(configuration.GetValue<string>("HttpClients:ESTADOS_API"));
                })
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)))
                .AddTypedClient(c => Refit.RestService.For<IGeoNamesEstadosServices>(c));
            
            services
                .AddHttpClient("CNPJA", c =>
                {
                    c.BaseAddress = new Uri(configuration.GetValue<string>("HttpClients:CNPJA"));
                })
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)))
                .AddTypedClient(c => Refit.RestService.For<ICNPJAServices>(c));
            
            services
                .AddHttpClient("BOMCONTROLE", c =>
                {
                    c.BaseAddress = new Uri(configuration.GetValue<string>("HttpClients:BOMCONTROLE"));
                })
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)))
                .AddTypedClient(c => Refit.RestService.For<IBCServices>(c));

            return services;
        }
    }
}
