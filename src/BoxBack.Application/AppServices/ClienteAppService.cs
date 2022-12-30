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
                throw new OperationCanceledException(io.Message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {ex.Message}");
                _rotinaEventHistoryAppService.UpdateWithStatusFalhaExecucaoHandle(ex.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(ex.Message);
            }
            #endregion

            #region Sincronization service
            try
            {
                await _clienteService.SincronizarFromTPAsync(token, rotinaEventHistoryId);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de sincronizar clientes a partir da api de terceiro. | {io.Message}");
                _rotinaEventHistoryAppService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }
            catch (ArgumentNullException an)
            {
                _logger.LogInformation($"Argumento nulo. | {an.Message}");
                _rotinaEventHistoryAppService.UpdateWithStatusFalhaExecucaoHandle(an.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(an.Message);
            }
            catch (Exception e) when (e is FormatException or OverflowException)
            {
                _logger.LogInformation($"Formato do argumento inválido ou problemas ou de casting ou conversões. | {e.Message}");
                _rotinaEventHistoryAppService.UpdateWithStatusFalhaExecucaoHandle(e.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(e.Message);
            }
            #endregion
        }
    }
} 