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
        private readonly IVendedorContratoRepository _vendedorContratoRepository;
        
        public VendedorComissaoService(ILogger<VendedorComissaoService> logger,
                                       IVendedorComissaoRepository vendedorComissaoRepository,
                                       IVendedorContratoService vendedorContratoService,
                                       IMapper mapper,
                                       IUnitOfWork unitOfWork,
                                       IClienteContratoRepository clienteContratoRepository,
                                       IRotinaEventHistoryService rotinaEventHistoryService,
                                       IClienteContratoFaturaRepository clienteContratoFaturaRepository,
                                       IVendedorContratoRepository vendedorContratoRepository)
        {
            _logger = logger;
            _vendedorComissaoRepository = vendedorComissaoRepository;
            _vendedorContratoService = vendedorContratoService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _clienteContratoRepository = clienteContratoRepository;
            _rotinaEventHistoryService = rotinaEventHistoryService;
            _clienteContratoFaturaRepository = clienteContratoFaturaRepository;
            _vendedorContratoRepository = vendedorContratoRepository;
        }
    
        public async Task GerarComissoesByVendedorIdAsync(Guid rotinaEventHistoryId, Guid vendedorId)
        {
            #region Generals Validators
            var vendedorComissaoToValidations = new VendedorComissao();
            vendedorComissaoToValidations.VendedorId = vendedorId;

            VendedorComissaoParamsValidator validator = new VendedorComissaoParamsValidator();
            var validatorResult = validator.Validate(vendedorComissaoToValidations);
            if (!validatorResult.IsValid)
            {
                foreach (var failure in validatorResult.Errors)
                {
                    _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | Property => {failure.PropertyName}, ErrorMessage => {failure.ErrorMessage}");
                    _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(failure.ErrorMessage, rotinaEventHistoryId);
                }

                throw new OperationCanceledException(validatorResult.Errors.FirstOrDefault().ErrorMessage);
            }
            #endregion

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

            var dataInicio = rotinaEventHistory.Rotina.DataCompetenciaInicio.Date;
            var dataFim = rotinaEventHistory.Rotina.DataCompetenciaFim.Date;
            #endregion

            #region Get contratos ativos e por vendedorId
            VendedorContrato[] vendedorContratos;;
            try
            {
                vendedorContratos = await _vendedorContratoRepository.GetAllAtivosWithIncludesByVendedorIdAsync(vendedorId);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter os contratos do vendedor para seguir com a geração das comissões. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }
            #endregion

            #region Get faturas comissionáveis do período de competência informado
            ClienteContratoFatura[] clienteContratosFaturas;
            try
            {
                clienteContratosFaturas = vendedorContratos
                                            .SelectMany(x => x.ClienteContrato.ClientesContratosFaturas)
                                            .Where(x => x.Quitado.Equals(true) &&
                                                   x.DataCompetencia >= dataInicio &&
                                                   x.DataCompetencia <= dataFim).ToArray();
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter as faturas de contratos comissionáveis para seguir com a geração das comissões. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }
            #endregion

            #region Calcular valor comissões
            Int64 totalComissoesGeradas = 0;
            Int64 totalComissoesNaoGeradas = 0;
            for (var i = 0; i < clienteContratosFaturas.Length; i++)
            {
                var vendedoresContrato = clienteContratosFaturas[i].ClienteContrato.VendedoresContratos.ToArray();
                for (var b = 0; b < vendedoresContrato.Length; b++)
                {
                    if (!await AlreadyByFaturaIdAndVendedorId(clienteContratosFaturas[i].Id, vendedoresContrato[b].VendedorId)){
                        var vendedorComissao = new VendedorComissao()
                        {
                            Id = Guid.NewGuid(),
                            ClienteContratoId = clienteContratosFaturas[i].ClienteContratoId,
                            VendedorId = vendedoresContrato[b].VendedorId,
                            ClienteContratoFaturaId = clienteContratosFaturas[i].Id
                        };

                        if (vendedoresContrato[b].ComissaoPercentual != 0)
                        {
                            vendedorComissao.ValorComissao = vendedoresContrato[b].ClienteContrato.ValorContrato * vendedoresContrato[b].ComissaoPercentual / 100;
                        }
                        else
                        {
                            vendedorComissao.ValorComissao = vendedoresContrato[b].ComissaoReais;
                        }

                        _vendedorComissaoRepository.Add(vendedorComissao);
                        totalComissoesGeradas++;
                    } else {
                        totalComissoesNaoGeradas++;
                    }
                }
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
                _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalComissoesGeradas, totalComissoesNaoGeradas);
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
                clientesFaturas = await _clienteContratoFaturaRepository.GetAllQuitadasByCompetenciaAsync(dataInicio, dataFim);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter as faturas de contratos comissionáveis para seguir com a geração das comissões. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message) ;
            }
            #endregion

            #region Calcular valor comissões
            Int64 totalComissoesGeradas = 0;
            Int64 totalComissoesNaoGeradas = 0;
            for (var i = 0; i < clientesFaturas.Length; i++)
            {
                var vendedoresContrato = clientesFaturas[i].ClienteContrato.VendedoresContratos.ToArray();
                for (var b = 0; b < vendedoresContrato.Length; b++)
                {
                    if (!await AlreadyByFaturaIdAndVendedorId(clientesFaturas[i].Id, vendedoresContrato[b].VendedorId)){
                        var vendedorComissao = new VendedorComissao()
                        {
                            Id = Guid.NewGuid(),
                            ClienteContratoId = clientesFaturas[i].ClienteContratoId,
                            VendedorId = vendedoresContrato[b].VendedorId,
                            ClienteContratoFaturaId = clientesFaturas[i].Id
                        };

                        if (vendedoresContrato[b].ComissaoPercentual != 0)
                        {
                            vendedorComissao.ValorComissao = vendedoresContrato[b].ClienteContrato.ValorContrato * vendedoresContrato[b].ComissaoPercentual / 100;
                        }
                        else
                        {
                            vendedorComissao.ValorComissao = vendedoresContrato[b].ComissaoReais;
                        }

                        _vendedorComissaoRepository.Add(vendedorComissao);
                        totalComissoesGeradas++;
                    } else {
                        totalComissoesNaoGeradas++;
                    }
                }
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
                _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalComissoesGeradas, totalComissoesNaoGeradas);
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
            vendedorComissao.Id = id;

            VendedorComissaoParamsValidator validator = new VendedorComissaoParamsValidator();
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
        public async Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAndaDataCompetenciaFaturaAsync(Guid vendedorId, DateTime dataInicio, DateTime dataFim)
        {
            #region Validators
            var vendedorComissao = new VendedorComissao();
            vendedorComissao.VendedorId = vendedorId;

            VendedorComissaoParamsValidator validator = new VendedorComissaoParamsValidator();
            validator.ValidateAndThrow(vendedorComissao);
            #endregion

            #region Get data
            IEnumerable<VendedorComissao> vendedorComissoes = new List<VendedorComissao>();
            try
            {
                vendedorComissoes = await _vendedorComissaoRepository.GetAllWithIncludesByVendedorIdAndaDataCompetenciaFaturaAsync(vendedorId, dataInicio, dataFim);
            }
            catch (InvalidOperationException io)
            { 
                _logger.LogInformation($"Problemas ao obter as comissões de vendedores. | {io.Message}");
                throw;
            }
            #endregion

            return vendedorComissoes;
        }
        public async Task<IEnumerable<VendedorComissao>> GetAllWithIncludesByVendedorIdAsync(Guid vendedorId)
        {
            #region Validators
            var vendedorComissao = new VendedorComissao();
            vendedorComissao.VendedorId = vendedorId;

            VendedorComissaoParamsValidator validator = new VendedorComissaoParamsValidator();
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
        public async Task DeletePermanentlyAsync(Guid id)
        {
            #region Validators
            var vendedorComissao = new VendedorComissao();
            vendedorComissao.VendedorId = id;

            VendedorComissaoParamsValidator validator = new VendedorComissaoParamsValidator();
            validator.ValidateAndThrow(vendedorComissao);
            #endregion

            #region Get data to delete
            var vendedorComissaoToDelete = new VendedorComissao();
            try
            {
                vendedorComissaoToDelete = await _vendedorComissaoRepository.GetByIdAsync(id);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de fazer commit da deleção no banco.| {io.Message}");
                throw;
            }
            catch (ArgumentNullException an)
            {
                _logger.LogInformation($"Falhou tentativa de fazer commit da deleção no banco.| {an.Message}");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Falhou tentativa de fazer commit da deleção no banco.| {e.Message}");
                throw;
            }

            validator.ValidateAndThrow(vendedorComissaoToDelete);
            #endregion

            #region Delete
            try
            {
                _vendedorComissaoRepository.DeletePermanentlyAsync(vendedorComissaoToDelete);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de deletar permanentente uma comissão de vendedor.| {io.Message}");
                throw;
            }
            #endregion

            #region Commit without soft delete
            _unitOfWork.CommitWithoutSoftDelete();
            #endregion
        }

        #region Private methods
        private async Task<bool> AlreadyByFaturaIdAndVendedorId(Guid clienteContratoFaturaId, Guid vendedorId)
        {
            #region Required validations
            if (clienteContratoFaturaId == Guid.Empty)
            {
                throw new ArgumentNullException("Id da fatura requerido.");
            }

            if (vendedorId == Guid.Empty)
            {
                throw new ArgumentNullException("Id do vendedor requerido.");
            }
            #endregion

            #region Get contratos comissionáveis
            bool already;
            try
            {
                already = await _vendedorComissaoRepository
                                       .AlreadyByFaturaIdAndVendedorId(clienteContratoFaturaId, vendedorId);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de verificação de existência de registro de comissão para o id da fatura informado. | {io.Message}");
                throw new OperationCanceledException(io.Message);
            }
            #endregion

            return already;
        }
        #endregion

        public void Dispose()
        {
            _vendedorComissaoRepository.Dispose();
        }
    }
}