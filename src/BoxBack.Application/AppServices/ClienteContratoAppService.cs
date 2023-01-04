using System;
using System.Threading.Tasks;
using BoxBack.Application.Interfaces;
using BoxBack.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BoxBack.Application.AppServices
{
    public class ClienteContratoAppService : IClienteContratoAppService
    {
        private readonly ILogger _logger;
        private readonly IClienteContratoService _clienteContratoService;
        private readonly IRotinaAppService _rotinaAppService;
        private readonly IRotinaEventHistoryAppService _rotinaEventHistoryAppService;
        private readonly IChaveApiTerceiroAppService _chaveApiTerceiroAppService;

        public ClienteContratoAppService(ILogger<ClienteContratoAppService> logger,
                                         IClienteContratoService clienteContratoService,
                                         IRotinaAppService rotinaService,
                                         IRotinaEventHistoryAppService rotinaEventHistoryAppService,
                                         IChaveApiTerceiroAppService chaveApiTerceiroAppService) 
        {
            _logger = logger;
            _clienteContratoService = clienteContratoService;
            _rotinaAppService = rotinaService;
            _rotinaEventHistoryAppService = rotinaEventHistoryAppService;
            _chaveApiTerceiroAppService = chaveApiTerceiroAppService;
        }
        
        public async Task SyncFromTPAsync(Guid rotinaEventHistoryId)
        {
            #region Sincronization contratos de clientes
            try
            {
                await _clienteContratoService.AddFromThirdPartyAsync(rotinaEventHistoryId);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de sincronizar contratos de clientes a partir da api de terceiro. | {io.Message}");
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

        public async Task UpdateFromTPAsync(Guid rotinaEventHistoryId)
        {
            #region Update contratos de clientes
            try
            {
                await _clienteContratoService.UpdateFromThirdPartyAsync(rotinaEventHistoryId);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de atualizar dados de contratos de clientes a partir da api de terceiro. | {io.Message}");
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