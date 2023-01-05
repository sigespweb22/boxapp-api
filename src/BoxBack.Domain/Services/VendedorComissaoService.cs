using System;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.InterfacesRepositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Sigesp.Domain.InterfacesRepositories;
using BoxBack.Domain.Models;
using System.Linq;

namespace BoxBack.Domain.Services
{
    public class VendedorComissaoService : IVendedorComissaoService
    {
        private readonly ILogger _logger;
        private readonly IVendedorComissaoRepository _vendedorComissaoRepository;
        private readonly IVendedorContratoService _vendedorContratoService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteContratoRepository _clienteContratoRepository;
        private readonly IRotinaEventHistoryService _rotinaEventHistoryService;
        private readonly IVendedorContratoRepository _vendedorContratoRepository;
        private readonly IClienteContratoFaturaRepository _clienteContratoFaturaRepository;
        
        public VendedorComissaoService(ILogger<VendedorComissaoService> logger,
                                       IVendedorComissaoRepository vendedorComissaoRepository,
                                       IVendedorContratoService vendedorContratoService,
                                       IMapper mapper,
                                       IUnitOfWork unitOfWork,
                                       IClienteContratoRepository clienteContratoRepository,
                                       IRotinaEventHistoryService rotinaEventHistoryService,
                                       IVendedorContratoRepository vendedorContratoRepository,
                                       IClienteContratoFaturaRepository clienteContratoFaturaRepository)
        {
            _logger = logger;
            _vendedorComissaoRepository = vendedorComissaoRepository;
            _vendedorContratoService = vendedorContratoService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _clienteContratoRepository = clienteContratoRepository;
            _rotinaEventHistoryService = rotinaEventHistoryService;
            _vendedorContratoRepository = vendedorContratoRepository;
            _clienteContratoFaturaRepository = clienteContratoFaturaRepository;
        }
    
        public async Task GerarComissoesAsync(Guid rotinaEventHistoryId)
        {
            #region Obter as data de competencia na rotina
            var rotinaEventHistory = new RotinaEventHistory();
            try
            {
                rotinaEventHistory = await _rotinaEventHistoryService.GetByIdWithIncludeAsync(rotinaEventHistoryId);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter rotina event history para obter as datas de competência início e fim. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }
            catch (ArgumentNullException an)
            {
                _logger.LogInformation($"Argumento nulo. | {an.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(an.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(an.Message);
            }
            catch (Exception e) when (e is FormatException or OverflowException)
            {
                _logger.LogInformation($"Formato do argumento inválido ou problemas ou de casting ou conversões. | {e.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(e.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(e.Message);
            }

            if (rotinaEventHistory == null)
            {
                _logger.LogInformation($"Nenhum evento de rotina encontrado com o id informado afim de obter obter as datas de competência início e fim.");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle($"Nenhum evento de rotina encontrado com o id informado afim de obter obter as datas de competência início e fim.", rotinaEventHistoryId);
                throw new OperationCanceledException($"Nenhum evento de rotina encontrado com o id informado afim de obter obter as datas de competência início e fim.");
            }

            var dataInicio = rotinaEventHistory.Rotina.DataCompetenciaInicio;
            var dataFim = rotinaEventHistory.Rotina.DataCompetenciaFim;
            #endregion

            #region Get contratos comissionáveis
            VendedorContrato[] vendedoresContratos;
            try
            {
                vendedoresContratos = await _clienteContratoFaturaRepository.GetAllContratosComissionaveisByCompetenciaAsync(dataInicio, dataFim);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter os contratos vinculados aos vendedores para seguir com a geração das comissões. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }

            if (vendedoresContratos == null || vendedoresContratos.Count() <= 0)
            {
                _logger.LogInformation($"Nenhum contrato vinculado a um ou mais vendedores encontrado para iniciar a geração das comissões. | {vendedoresContratos.Count()}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Nenhum contrato de cliente encontrado para iniciar a sincronização.", rotinaEventHistoryId);
                throw new ArgumentNullException("Nenhum contrato vinculado a um ou mais vendedores encontrado para iniciar a geração das comissões.");
            }
            #endregion

            #region Calcular valor comissões
            Int64 totalComissoesGeradas = 0;
            for (var i = 0; i < vendedoresContratos.Length; i++)
            {
                var vendedorComissao = new VendedorComissao()
                {
                    Id = Guid.NewGuid(),
                    ClienteContratoId = vendedoresContratos[i].ClienteContratoId,
                    VendedorId = vendedoresContratos[i].VendedorId
                };

                if (vendedoresContratos[i].ComissaoPercentual != 0)
                {
                    vendedorComissao.ValorComissao = vendedoresContratos[i].ClienteContrato.ValorContrato * vendedoresContratos[i].ComissaoPercentual / 100;
                }
                else
                {
                    vendedorComissao.ValorComissao = vendedoresContratos[i].ComissaoReais;
                }

                _vendedorComissaoRepository.Add(vendedorComissao);
                totalComissoesGeradas++;
            }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();    
            }
            catch (InvalidOperationException io) {
                _logger.LogInformation($"Problemas ao efetuar commit. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new InvalidOperationException(io.Message); 
            }
            catch (Exception ex) {
                _logger.LogInformation($"Problemas ao efetuar commit. | {ex.InnerException.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(ex.InnerException.Message, rotinaEventHistoryId);
                throw new InvalidOperationException(ex.InnerException.Message); 
            }
            #endregion

            #region Create rotina event history of success
            try
            {
                _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalComissoesGeradas, 0);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {io.Message}");
                throw new InvalidOperationException(io.Message, io.InnerException);
            }
            catch (ArgumentNullException an) 
            {
                _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {an.Message}");
                throw new InvalidOperationException(an.Message, an.InnerException);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {ex.Message}");
                throw new InvalidOperationException(ex.Message, ex.InnerException);
            }
            #endregion
        }

        public void Dispose()
        {
            _vendedorComissaoRepository.Dispose();
        }
    }
}