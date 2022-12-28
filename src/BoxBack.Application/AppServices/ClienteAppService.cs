using System;
using System.Threading;
using System.Threading.Tasks;
using BoxBack.Application.Interfaces;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BoxBack.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly ILogger _logger;
        private readonly IClienteService _clienteService;
        private readonly IRotinaAppService _rotinaAppService;
        private readonly IRotinaEventHistoryAppService _rotinaEventHistoryAppService;
        private readonly IChaveApiTerceiroAppService _chaveApiTerceiroAppService;

        public ClienteAppService(ILogger<ClienteAppService> logger,
                                 IClienteService clienteService,
                                 IRotinaAppService rotinaService,
                                 IRotinaEventHistoryAppService rotinaEventHistoryAppService,
                                 IChaveApiTerceiroAppService chaveApiTerceiroAppService) 
        {
            _logger = logger;
            _clienteService = clienteService;
            _rotinaAppService = rotinaService;
            _rotinaEventHistoryAppService = rotinaEventHistoryAppService;
            _chaveApiTerceiroAppService = chaveApiTerceiroAppService;
        }
        
        public async Task SincronizarFromTPAsync(CancellationTokenSource tokenSource, Guid rotinaEventHistoryId)
        {
            #region Chave api resolve - Token
            String token = string.Empty;
            try
            {
                token = $"ApiKey {await _chaveApiTerceiroAppService.GetValidKeyByApiTerceiroNome(ApiTerceiroEnum.BOM_CONTROLE)}";
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {io.Message}");
                _rotinaEventHistoryAppService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {ex.Message}");
                _rotinaEventHistoryAppService.UpdateWithStatusFalhaExecucaoHandle(ex.Message, rotinaEventHistoryId);
            }
            #endregion

            try
            {
                await _clienteService.SincronizarFromTPAsync(token).ConfigureAwait(false);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {io.Message}");
                _rotinaEventHistoryAppService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
            }
        }
    }
} 