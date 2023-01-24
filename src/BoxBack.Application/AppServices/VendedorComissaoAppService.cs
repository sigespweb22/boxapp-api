using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Application.ViewModels.Date;
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
        private readonly IMapper _mapper;


        public VendedorComissaoAppService(ILogger<ClienteContratoFaturaAppService> logger,
                                          IVendedorComissaoService vendedorComissaoService,
                                          IRotinaEventHistoryAppService rotinaEventHistoryAppService,
                                          IRotinaEventHistoryService rotinaEventHistoryService,
                                          IMapper mapper)
        {
            _logger = logger;
            _vendedorComissaoService = vendedorComissaoService;
            _rotinaEventHistoryAppService = rotinaEventHistoryAppService;
            _rotinaEventHistoryService = rotinaEventHistoryService;
            _mapper = mapper;
        }

        public async Task GerarComissoesByVendedorIdAsync(Guid rotinaEventHistoryId, Guid vendedorId)
        {
            #region Gerar comissões
            try
            {
                await _vendedorComissaoService.GerarComissoesByVendedorIdAsync(rotinaEventHistoryId, vendedorId);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de gerar as comissões para o vendedor informado. | {io.Message}");
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
        public async Task<IEnumerable<VendedorComissaoViewModel>> GetAllWithIncludesByVendedorIdAndaDataCompetenciaFaturaAsync(string vendedorId, DataPeriodoViewModel dataPeriodo)
        {
            #region Map id vendedor
            Guid vendedorIdConverted;
            try
            {   
                Guid.TryParse(vendedorId, out vendedorIdConverted);
            }
            catch (InvalidCastException ic)
            {
                _logger.LogInformation($"Falhou tentativa de mapear o id do vendedor. | {ic.Message}");
                throw new InvalidCastException($"Falhou tentativa de mapear o id do vendedor. | {ic.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de mapear o id do vendedor.  | {ex.Message}");
                throw;
            }
            #endregion

            #region Get and map data
            try
            {
                return _mapper.Map<IEnumerable<VendedorComissaoViewModel>>(await _vendedorComissaoService.GetAllWithIncludesByVendedorIdAndaDataCompetenciaFaturaAsync(vendedorIdConverted, Convert.ToDateTime(dataPeriodo.DataInicio), Convert.ToDateTime(dataPeriodo.DataFim)));
            }
            catch (InvalidCastException ic)
            {
                _logger.LogInformation($"Falhou tentativa de mapear as comissões do vendedor. | {ic.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de mapear as comissões do vendedor. | {ex.Message}");
                throw;
            }
            #endregion
        }
        public async Task<IEnumerable<VendedorComissaoViewModel>> GetAllWithIncludesByVendedorIdAsync(string vendedorId)
        {
            #region Map id vendedor
            Guid vendedorIdConverted;
            try
            {   
                Guid.TryParse(vendedorId, out vendedorIdConverted);
            }
            catch (InvalidCastException ic)
            {
                _logger.LogInformation($"Falhou tentativa de mapear o id do vendedor. | {ic.Message}");
                throw new InvalidCastException($"Falhou tentativa de mapear o id do vendedor. | {ic.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de mapear o id do vendedor.  | {ex.Message}");
                throw;
            }
            #endregion

            #region Get and map data
            try
            {
                return _mapper.Map<IEnumerable<VendedorComissaoViewModel>>(await _vendedorComissaoService.GetAllWithIncludesByVendedorIdAsync(vendedorIdConverted));
            }
            catch (InvalidCastException ic)
            {
                _logger.LogInformation($"Falhou tentativa de mapear as comissões do vendedor. | {ic.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de mapear as comissões do vendedor. | {ex.Message}");
                throw;
            }
            #endregion
        }
        public async Task<bool> AlterStatusAsync(Guid id)
        {
            return await _vendedorComissaoService.AlterStatusAsync(id);
        }
        public async Task DeletePermanentlyAsync(Guid id)
        {
            await _vendedorComissaoService.DeletePermanentlyAsync(id);
        }
    }
}