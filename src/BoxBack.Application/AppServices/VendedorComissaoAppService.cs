using System;
using System.Collections.Generic;
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
        private readonly IRotinaEventHistoryService _rotinaEventHistoryService;


        public VendedorComissaoAppService(ILogger<ClienteContratoFaturaAppService> logger,
                                          IVendedorComissaoService vendedorComissaoService,
                                          IRotinaEventHistoryAppService rotinaEventHistoryAppService,
                                          IRotinaEventHistoryService rotinaEventHistoryService)
        {
            _logger = logger;
            _vendedorComissaoService = vendedorComissaoService;
            _rotinaEventHistoryAppService = rotinaEventHistoryAppService;
            _rotinaEventHistoryService = rotinaEventHistoryService;
        }

        public async Task GerarComissoesAsync(Guid rotinaEventHistoryId)
        {
            #region Gerar comissões
            try
            {
                await _vendedorComissaoService.GerarComissoesAsync(rotinaEventHistoryId);
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
        // public async Task<IEnumerable<VendedorComissaoViewModel>> GetallAsync()
        // {
        //     try
        //     {

        //     }
        //     catch (Invali ic)
        //     {
        //         _logger.LogInformation($"Falhou tentativa de mapear as comissões de vendedores. | {ic.Message}");
        //         throw;
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogInformation($"Falhou tentativa de mapear as comissões de vendedores. | {ex.Message}");
        //         throw;
        //     }

        //     try
        //     {
                
        //     }
        //     catch (InvalidCastException ic)
        //     {
        //         _logger.LogInformation($"Falhou tentativa de mapear as comissões de vendedores. | {ic.Message}");
        //         throw;
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogInformation($"Falhou tentativa de mapear as comissões de vendedores. | {ex.Message}");
        //         throw;
        //     }
        // }

        public async Task<bool> AlterStatusAsync(Guid id)
        {
            return await _vendedorComissaoService.AlterStatusAsync(id);
        }
    }
}