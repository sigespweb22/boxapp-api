using System;
using System.Threading.Tasks;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BoxBack.Application.AppServices
{
    public class VendedorComissaoAppService : IVendedorComissaoAppService
    {
        private readonly ILogger _logger;
        private readonly IVendedorComissaoService _vendedorComissaoService;
        private readonly IRotinaEventHistoryAppService _rotinaEventHistoryAppService;


        public VendedorComissaoAppService(ILogger<ClienteContratoFaturaAppService> logger,
                                          IVendedorComissaoService vendedorComissaoService,
                                          IRotinaEventHistoryAppService rotinaEventHistoryAppService)
        {
            _logger = logger;
            _vendedorComissaoService = vendedorComissaoService;
            _rotinaEventHistoryAppService = rotinaEventHistoryAppService;
        }

        public async Task GerarComissoesAsync(Guid rotinaEventHistoryId)
        {
            #region Obter as data de competencia na rotina
            var dataInicio = DateTime.Now;
            var dataFim = DateTime.Now;
            #endregion

            #region Gerar comissões
            try
            {
                await _vendedorComissaoService.GerarComissoesAsync(rotinaEventHistoryId, dataInicio, dataFim);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de gerar as comissões de vendedores. | {io.Message}");
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