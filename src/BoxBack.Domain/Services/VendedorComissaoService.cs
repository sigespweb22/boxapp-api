using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.InterfacesRepositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Sigesp.Domain.InterfacesRepositories;
using BoxBack.Domain.Models;
using System.Linq;
using BoxBack.Domain.Validators.VendedorComissaoValidator;
using FluentValidation;

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
        private readonly IClienteContratoFaturaRepository _clienteContratoFaturaRepository;
        
        public VendedorComissaoService(ILogger<VendedorComissaoService> logger,
                                       IVendedorComissaoRepository vendedorComissaoRepository,
                                       IVendedorContratoService vendedorContratoService,
                                       IMapper mapper,
                                       IUnitOfWork unitOfWork,
                                       IClienteContratoRepository clienteContratoRepository,
                                       IRotinaEventHistoryService rotinaEventHistoryService,
                                       IClienteContratoFaturaRepository clienteContratoFaturaRepository)
        {
            _logger = logger;
            _vendedorComissaoRepository = vendedorComissaoRepository;
            _vendedorContratoService = vendedorContratoService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _clienteContratoRepository = clienteContratoRepository;
            _rotinaEventHistoryService = rotinaEventHistoryService;
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

            #region Get faturas comissionáveis do período de competência informado
            ClienteContratoFatura[] clientesFaturas;
            try
            {
                clientesFaturas = await _clienteContratoFaturaRepository.GetAllByCompetenciaAsAndQuitadasync(dataInicio, dataFim);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter as faturas de contratos comissionáveis para seguir com a geração das comissões. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message) ;
            }

            #region Get contratos comissionáveis
            VendedorContrato[] vendedoresContratos;
            try
            {
                vendedoresContratos = clientesFaturas.SelectMany(x => x.ClienteContrato.VendedoresContratos).Distinct().ToArray();
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter os contratos vinculados aos vendedores para seguir com a geração das comissões. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }
            #endregion

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
        public async Task<bool> AlterStatusAsync(Guid id)
        {
            #region Generals Validators
            var vendedorComissao = new VendedorComissao();
            vendedorComissao.Id = Guid.Empty;

            VendedorComissaoAlterStatusValidator validator = new VendedorComissaoAlterStatusValidator();
            validator.ValidateAndThrow(vendedorComissao);
            #endregion

            #region Get data
            try
            {
                vendedorComissao = await _vendedorComissaoRepository.GetByIdAsync(id);
            }
            catch (InvalidOperationException io)
            { 
                _logger.LogInformation($"Problemas ao obter a comissão para alterar seu status. | {io.Message}");
                throw;
            }
            
            validator.ValidateAndThrow(vendedorComissao);
            #endregion

            #region Map
            try
            {
                switch(vendedorComissao.IsDeleted)
                {
                    case true:
                        vendedorComissao.IsDeleted = false;
                        break;
                    case false:
                        vendedorComissao.IsDeleted = true;
                        break;
                }
            }
            catch (InvalidCastException ic)
            { 
                _logger.LogInformation($"Problemas ao mapear os dados de comissão para alterar seu status. | {ic.Message}");
                throw;
            }
            #endregion

            #region Persistence
            try
            {
                _vendedorComissaoRepository.Update(vendedorComissao);
            }
            catch (InvalidOperationException io)
            { 
                _logger.LogInformation($"Problemas ao fazer update para alterar status. | {io.Message}");
                throw;
            }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch (InvalidOperationException io)
            { 
                _logger.LogInformation($"Problemas ao obter a comissão para alterar seu status. | {io.Message}");
                throw;
            }
            #endregion

            return true;
        }
        public async Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAsync(Guid vendedorId)
        {
            #region Validators
            var vendedorComissao = new VendedorComissao();
            vendedorComissao.VendedorId = vendedorId;

            VendedorComissaoValidator validator = new VendedorComissaoValidator();
            validator.ValidateAndThrow(vendedorComissao);
            #endregion

            #region Get data
            IEnumerable<VendedorComissao> vendedorComissoes = new List<VendedorComissao>();
            try
            {
                vendedorComissoes = await _vendedorComissaoRepository.GetAllWithIncludesByVendedorIdAsync(vendedorId);
            }
            catch (InvalidOperationException io)
            { 
                _logger.LogInformation($"Problemas ao obter as comissões de vendedores. | {io.Message}");
                throw;
            }
            #endregion

            return vendedorComissoes;
        }

        public void Dispose()
        {
            _vendedorComissaoRepository.Dispose();
        }
    }
}