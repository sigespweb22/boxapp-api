using System;
using System.Linq;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Sigesp.Domain.InterfacesRepositories;
using System.Collections.Generic;
using BoxBack.Domain.ModelsServices;
using BoxBack.Domain.ServicesThirdParty;
using BoxBack.Domain.InterfacesRepositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Services
{
    public class ClienteContratoFaturaService : IClienteContratoFaturaService
    {
        private readonly ILogger _logger;
        private readonly IClienteContratoFaturaRepository _clienteContratoFaturaRepository;
        private readonly IChaveApiTerceiroService _chaveApiTerceiroService;
        private readonly IRotinaEventHistoryRepository _rotinaEventHistoryRepository;
        private readonly IRotinaRepository _rotinaRepository;
        private readonly IBCServices _bcServices;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRotinaEventHistoryService _rotinaEventHistoryService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteContratoRepository _clienteContratoRepository;
        
        public ClienteContratoFaturaService(ILogger<ClienteContratoFaturaService> logger,
                                            IClienteContratoFaturaRepository clienteContratoFaturaRepository,
                                            IChaveApiTerceiroService chaveApiTerceiroService,
                                            IRotinaEventHistoryRepository rotinaEventHistoryRepository,
                                            IRotinaRepository rotinaRepository,
                                            IBCServices bcServices,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork,
                                            IRotinaEventHistoryService rotinaEventHistoryService,
                                            IClienteRepository clienteRepository,
                                            IClienteContratoRepository clienteContratoRepository)
        {
            _logger = logger;
            _clienteContratoFaturaRepository = clienteContratoFaturaRepository;
            _chaveApiTerceiroService = chaveApiTerceiroService;
            _rotinaEventHistoryRepository = rotinaEventHistoryRepository;
            _rotinaRepository = rotinaRepository;
            _bcServices = bcServices;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _rotinaEventHistoryService = rotinaEventHistoryService;
            _clienteRepository = clienteRepository;
            _clienteContratoRepository = clienteContratoRepository;
        }
    
        public async Task AddQuitadasFromThirdPartyAsync(Guid rotinaEventHistoryId)
        {
            #region Get contratos
            ClienteContrato[] clientesContratos;
            try
            {
                clientesContratos = _clienteContratoRepository.GetAll().ToArray();
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter os contratos para seguir com a sincronização das faturas. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }

            if (clientesContratos == null || clientesContratos.Count() <= 0)
            {
                _logger.LogInformation($"Nenhum contrato de cliente encontrado para iniciar a sincronização. | {clientesContratos.Count()}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Nenhum contrato de cliente encontrado para iniciar a sincronização", rotinaEventHistoryId);
                throw new ArgumentNullException("Nenhum contrato de cliente encontrato para iniciar a sincronização com api de terceiro.");
            }
            #endregion

            #region Chave api resolve - Token
            String token = string.Empty;
            try
            {
                token = $"ApiKey {await _chaveApiTerceiroService.GetValidKeyByApiTerceiroNome(ApiTerceiroEnum.BOM_CONTROLE)}";
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {ex.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(ex.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(ex.Message);
            }
            #endregion

            #region Get data Bom Controle (Third Party) and map and persistance faturas
            BCContratoModelService clientesContratosThirdParty = new BCContratoModelService();
            Int64 totalSincronizado = 0;
            for (var a = 0; a < clientesContratos.Count(); a++)
            {
                if (clientesContratos[a].BomControleContratoId == 0) continue;
                
                try
                {
                    clientesContratosThirdParty = await _bcServices.VendaContratoObter(clientesContratos[a].BomControleContratoId, true, token);
                }
                catch (Exception e) when (e is FormatException or OverflowException) {
                    _logger.LogInformation($"Falhou tentativa de obter os contratos a partir da api de terceiro. | {e.Message}");
                    _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(e.Message, rotinaEventHistoryId); 
                    throw new Exception(e.Message, e.InnerException);
                }

                if (clientesContratosThirdParty == null) continue;
                if (clientesContratosThirdParty.Faturas == null || clientesContratosThirdParty.Faturas.Count() == 0) continue;

                BCFaturaModelService[] clientesContratosFaturasThirdParty = clientesContratosThirdParty.Faturas.ToArray();

                for (var b = 0; b < clientesContratosFaturasThirdParty.Length; b++)
                {
                    var clienteContratoFatura = new ClienteContratoFatura();
                    try
                    {
                        clienteContratoFatura.Id = Guid.NewGuid();
                        clienteContratoFatura = _mapper.Map<ClienteContratoFatura>(clientesContratosFaturasThirdParty[b]);
                        clienteContratoFatura.ClienteContratoId = clientesContratos[a].Id;
                    }
                    catch (InvalidCastException ic) { 
                        _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {ic.Message}");
                        _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do cliente para sincronização", rotinaEventHistoryId);
                        throw new InvalidOperationException(ic.Message); 
                    }
                    catch (InvalidOperationException io) { 
                        _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {io.Message}");
                        _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do contrato do cliente", rotinaEventHistoryId);
                        throw new InvalidOperationException(io.Message); 
                    }
                    catch (Exception ex) { 
                        _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {ex.Message}");
                        _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização.", rotinaEventHistoryId);
                        throw new InvalidOperationException(ex.Message); 
                    }

                    // check to double
                    if (AlreadyClienteContratoFaturaAsync(clienteContratoFatura)) continue;

                    try
                    {
                        await _clienteContratoFaturaRepository.AddAsync(clienteContratoFatura);
                        totalSincronizado++;
                    }
                    catch (InvalidOperationException io) { 
                        _logger.LogInformation($"Problemas ao adicionar fatura de contrato de cliente. | {io.Message}");
                        _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao adicionar fatura de contrato cliente", rotinaEventHistoryId);
                        throw new InvalidOperationException(io.Message);
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
            #endregion

            #region Create rotina event history of success
            try
            {
                _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalSincronizado, 0);
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
        public async Task AddNaoQuitadasFromThirdPartyAsync(Guid rotinaEventHistoryId)
        {
            #region Get contratos
            ClienteContrato[] clientesContratos;
            try
            {
                clientesContratos = _clienteContratoRepository.GetAll().ToArray();
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter os contratos para seguir com a sincronização das faturas. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }

            if (clientesContratos == null || clientesContratos.Count() <= 0)
            {
                _logger.LogInformation($"Nenhum contrato de cliente encontrado para iniciar a sincronização. | {clientesContratos.Count()}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Nenhum contrato de cliente encontrado para iniciar a sincronização", rotinaEventHistoryId);
                throw new ArgumentNullException("Nenhum contrato de cliente encontrato para iniciar a sincronização com api de terceiro.");
            }
            #endregion

            #region Chave api resolve - Token
            String token = string.Empty;
            try
            {
                token = $"ApiKey {await _chaveApiTerceiroService.GetValidKeyByApiTerceiroNome(ApiTerceiroEnum.BOM_CONTROLE)}";
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {ex.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(ex.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(ex.Message);
            }
            #endregion

            #region Get data Bom Controle (Third Party) and map and persistance faturas
            BCContratoModelService clientesContratosThirdParty = new BCContratoModelService();
            Int64 totalSincronizado = 0;
            for (var a = 0; a < clientesContratos.Count(); a++)
            {
                if (clientesContratos[a].BomControleContratoId == 0) continue;
                
                try
                {
                    clientesContratosThirdParty = await _bcServices.VendaContratoObter(clientesContratos[a].BomControleContratoId, false, token);
                }
                catch (Exception e) when (e is FormatException or OverflowException) {
                    _logger.LogInformation($"Falhou tentativa de obter os contratos a partir da api de terceiro. | {e.Message}");
                    _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(e.Message, rotinaEventHistoryId); 
                    throw new Exception(e.Message, e.InnerException);
                }

                if (clientesContratosThirdParty == null) continue;
                if (clientesContratosThirdParty.Faturas == null || clientesContratosThirdParty.Faturas.Count() == 0) continue;

                BCFaturaModelService[] clientesContratosFaturasThirdParty = clientesContratosThirdParty.Faturas.ToArray();

                for (var b = 0; b < clientesContratosFaturasThirdParty.Length; b++)
                {
                    var clienteContratoFatura = new ClienteContratoFatura();
                    try
                    {
                        clienteContratoFatura.Id = Guid.NewGuid();
                        clienteContratoFatura = _mapper.Map<ClienteContratoFatura>(clientesContratosFaturasThirdParty[b]);
                        clienteContratoFatura.ClienteContratoId = clientesContratos[a].Id;
                    }
                    catch (InvalidCastException ic) { 
                        _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {ic.Message}");
                        _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do cliente para sincronização", rotinaEventHistoryId);
                        throw new InvalidOperationException(ic.Message); 
                    }
                    catch (InvalidOperationException io) { 
                        _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {io.Message}");
                        _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do contrato do cliente", rotinaEventHistoryId);
                        throw new InvalidOperationException(io.Message); 
                    }
                    catch (Exception ex) { 
                        _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {ex.Message}");
                        _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização.", rotinaEventHistoryId);
                        throw new InvalidOperationException(ex.Message); 
                    }

                    // check to double
                    if (AlreadyClienteContratoFaturaAsync(clienteContratoFatura)) continue;

                    try
                    {
                        await _clienteContratoFaturaRepository.AddAsync(clienteContratoFatura);
                        totalSincronizado++;
                    }
                    catch (InvalidOperationException io) { 
                        _logger.LogInformation($"Problemas ao adicionar fatura de contrato de cliente. | {io.Message}");
                        _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao adicionar fatura de contrato cliente", rotinaEventHistoryId);
                        throw new InvalidOperationException(io.Message);
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
            #endregion

            #region Create rotina event history of success
            try
            {
                _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalSincronizado, 0);
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
        public async Task UpdateFromThirdPartyAsync(Guid rotinaEventHistoryId)
        {
            #region Get faturas
            ClienteContratoFatura[] clientesContratosFaturas;
            try
            {
                clientesContratosFaturas = _clienteContratoFaturaRepository.GetAll().ToArray();
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter as faturas de contratos de clientes para seguir com a sincronização das faturas. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }

            if (clientesContratosFaturas == null || clientesContratosFaturas.Count() <= 0)
            {
                _logger.LogInformation($"Nenhuma fatura de contrato de cliente encontrada para iniciar a atualização. | {clientesContratosFaturas.Count()}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Nenhuma fatura de contrato de cliente encontrada para iniciar a atualização", rotinaEventHistoryId);
                throw new ArgumentNullException("Nenhuma fatura de contrato de cliente encontrada para iniciar a atualização.");
            }
            #endregion

            #region Chave api resolve - Token
            String token = string.Empty;
            try
            {
                token = $"ApiKey {await _chaveApiTerceiroService.GetValidKeyByApiTerceiroNome(ApiTerceiroEnum.BOM_CONTROLE)}";
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de obter um token de api de terceiro. | {ex.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(ex.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(ex.Message);
            }
            #endregion

            #region Get data Bom Controle (Third Party) to map and update faturas
            BCFaturaModelService faturaThirdParty = new BCFaturaModelService();
            Int64 totalFaturasAtualizadas = 0;
            var clienteContratoFaturaMapToUpdateRange = new List<ClienteContratoFatura>();
            for (var a = 0; a < clientesContratosFaturas.Length; a++)
            {
                if (clientesContratosFaturas[a].BomControleFaturaId == 0) continue;
                
                try
                {
                    faturaThirdParty = await _bcServices.FaturaObter(clientesContratosFaturas[a].BomControleFaturaId, token);
                }
                catch (Exception e) when (e is FormatException or OverflowException) {
                    _logger.LogInformation($"Falhou tentativa de obter uma fatura a partir da api de terceiro. | {e.Message}");
                    _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(e.Message, rotinaEventHistoryId); 
                    throw new Exception(e.Message, e.InnerException);
                }

                if (faturaThirdParty == null) continue;

                var clienteContratoFaturaMap = new ClienteContratoFatura();
                try
                {
                    clienteContratoFaturaMap = _mapper.Map<BCFaturaModelService, ClienteContratoFatura>(faturaThirdParty, clientesContratosFaturas[a]);
                }
                catch (InvalidCastException ic) { 
                    _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {ic.Message}");
                    _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do cliente para sincronização", rotinaEventHistoryId);
                    throw new InvalidOperationException(ic.Message); 
                }
                catch (InvalidOperationException io) { 
                    _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {io.Message}");
                    _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do contrato do cliente", rotinaEventHistoryId);
                    throw new InvalidOperationException(io.Message);
                }
                catch (Exception ex) {
                    _logger.LogInformation($"Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização. | {ex.Message}");
                    _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento das faturas de contratos de cliente para seguir com a sincronização.", rotinaEventHistoryId);
                    throw new InvalidOperationException(ex.Message); 
                }

                try
                {
                    clienteContratoFaturaMapToUpdateRange.Add(clienteContratoFaturaMap);    
                }
                catch (OperationCanceledException oc) { 
                    _logger.LogInformation($"Problemas ao criar uma lista de faturas para atualizar e seguir com a sincronização. | {oc.Message}");
                    _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao criar uma lista de faturas para atualizar e seguir com a sincronização", rotinaEventHistoryId);
                    throw new OperationCanceledException(oc.Message); 
                }
                catch (InvalidOperationException io) { 
                    _logger.LogInformation($"Problemas ao criar uma lista de faturas para atualizar e seguir com a sincronização. | {io.Message}");
                    _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao criar uma lista de faturas para atualizar e seguir com a sincronização", rotinaEventHistoryId);
                    throw new InvalidOperationException(io.Message); 
                }
            }

            // update range faturas
            try
            {
                _clienteContratoFaturaRepository.UpdateRange(clienteContratoFaturaMapToUpdateRange);
                totalFaturasAtualizadas++;
            }
            catch (OperationCanceledException oc) { 
                _logger.LogInformation($"Problemas ao atualizar fatura de contrato de cliente. | {oc.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao atualizar fatura de contrato de cliente", rotinaEventHistoryId);
                throw new OperationCanceledException(oc.Message); 
            }
            catch (InvalidOperationException io) { 
                _logger.LogInformation($"Problemas ao atualizar fatura de contrato de cliente. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao atualizar fatura de contrato cliente", rotinaEventHistoryId);
                throw new InvalidOperationException(io.Message);
            }
            catch (Exception ex) { 
                _logger.LogInformation($"Problemas ao atualizar fatura de contrato de cliente. | {ex.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao atualizar fatura de contrato cliente", rotinaEventHistoryId);
                throw new InvalidOperationException(ex.Message);
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
            #endregion

            #region Create rotina event history of success
            try
            {
                _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalFaturasAtualizadas, 0);
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

        #region Private methods
        private bool AlreadyClienteContratoFaturaAsync(ClienteContratoFatura clienteContratoFatura)
        {
            #region General validations
            if (clienteContratoFatura.ClienteContratoId == Guid.Empty) throw new ArgumentException("Id contrato requerido.");
            if (clienteContratoFatura.Valor == 0) throw new ArgumentException("Valor requerido.");
            if (clienteContratoFatura.NumeroParcela == 0) throw new ArgumentException("Número parcela requerido.");
            #endregion

            #region Check to already
            // check to same clienteContratoId, dataCompentencia, valor e numeroParcela
            var args = new AlreadyModelParam()
            {
                ClienteContratoId = clienteContratoFatura.ClienteContratoId,
                DataCompetencia = clienteContratoFatura.DataCompetencia,
                Valor = clienteContratoFatura.Valor,
                NumeroParcela = clienteContratoFatura.NumeroParcela
            };
            bool already;
            try
            {
                already = _clienteContratoFaturaRepository.AlreadyByParams(args);
            }
            catch { throw; }
            #endregion

             return already;
        }
        #endregion

        public void Dispose()
        {
            _clienteContratoFaturaRepository.Dispose();
        }
    }
}