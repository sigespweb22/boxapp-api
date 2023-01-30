using System.Linq;
using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BoxBack.Application.Interfaces;
using Microsoft.Extensions.Hosting;
using BoxBack.Domain.Interfaces;
using Sigesp.Domain.InterfacesRepositories;
using System.Collections.Generic;
using BoxBack.Domain.Models;

namespace BoxBack.WebApi.ScheduleServices
{
    public class RotinaScheduleService : IHostedService, IDisposable
    {
        private readonly ILogger<RotinaScheduleService> _logger;
        private int executionCount = 0;
        private Timer _timerNotification;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RotinaScheduleService(ILogger<RotinaScheduleService> logger,
                                     IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Tarefa iniciada...");
            
            _timerNotification = new Timer(RunJob, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
            return Task.CompletedTask;
        }

        public void RunJob(object state)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                #region Log
                var count = Interlocked.Increment(ref executionCount);

                _logger.LogInformation(
                    "O Serviço Hospedado Temporizado está funcionando... Contagem: {Count}", count);
                #endregion

                #region Criar histórico de rotina
                // create rotina event history
                var rotinaEventHistoryId = Guid.NewGuid();

                var rotinaId = new Guid("ac9faa63-bdff-4c0a-8469-b188f710cae7");
                var scopeRotinaEventHistory = scope.ServiceProvider.GetService<IRotinaEventHistoryAppService>();
                try
                {
                    scopeRotinaEventHistory.AddWithStatusEmExecucaoHandleAsync(rotinaId, rotinaEventHistoryId);
                }
                catch (NullReferenceException nr)
                {
                    _logger.LogWarning($"{nr.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning($"{ex.Message}");
                    throw;
                }
                #endregion

                #region Executar rotina 1
                // Vou ter que implementar todas as funcionalidades dos serviços inline,
                // devido a questões de escopo
                // ou implementar todas as chamadas internas do serviço principal
                // diretamente no repositório
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken cToken = source.Token;

                var scopeSincronizarFromTPAsync = scope.ServiceProvider.GetService<IClienteService>();
                var token = "ApiKey Z0EjZPzTOb-AJb42L6EVYZFO5wPxMFdXtJo6Jv7M-eSC8YwqcGgmfzbcz4sgR3BxynsbTrCaUm0r0iUV-9PrBX73B9hGUu5uHaUUcTkvYNyhbXzYG7zLggKd7MwMR1qwsW16kQFhc94.";

                try
                {
                    scopeSincronizarFromTPAsync.SyncAsync(token, rotinaEventHistoryId, scope);
                }
                catch (NullReferenceException nr)
                {
                    _logger.LogWarning($"{nr.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning($"{ex.Message}");
                    throw;
                }
                #endregion
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timerNotification?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timerNotification?.Dispose();
        }
    }
}