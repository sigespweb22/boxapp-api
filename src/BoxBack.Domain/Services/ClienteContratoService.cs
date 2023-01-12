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
    public class ClienteContratoService : IClienteContratoService
    {
        private readonly ILogger _logger;
        private readonly IClienteContratoRepository _clienteContratoRepository;
        private readonly IChaveApiTerceiroService _chaveApiTerceiroService;
        private readonly IRotinaEventHistoryRepository _rotinaEventHistoryRepository;
        private readonly IRotinaRepository _rotinaRepository;
        private readonly IBCServices _bcServices;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRotinaEventHistoryService _rotinaEventHistoryService;
        private readonly IClienteRepository _clienteRepository;
        
        public ClienteContratoService(ILogger<ClienteContratoService> logger,
                                      IClienteContratoRepository clienteContratoRepository,
                                      IChaveApiTerceiroService chaveApiTerceiroService,
                                      IRotinaEventHistoryRepository rotinaEventHistoryRepository,
                                      IRotinaRepository rotinaRepository,
                                      IBCServices bcServices,
                                      IMapper mapper,
                                      IUnitOfWork unitOfWork,
                                      IRotinaEventHistoryService rotinaEventHistoryService,
                                      IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteContratoRepository = clienteContratoRepository;
            _chaveApiTerceiroService = chaveApiTerceiroService;
            _rotinaEventHistoryRepository = rotinaEventHistoryRepository;
            _rotinaRepository = rotinaRepository;
            _bcServices = bcServices;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _rotinaEventHistoryService = rotinaEventHistoryService;
            _clienteRepository = clienteRepository;
        }
    
        public async Task AddFromThirdPartyAsync(Guid rotinaEventHistoryId)
        {
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

            #region Get clientes
            Cliente[] clientes;
            try
            {
                clientes = _clienteRepository.GetAll().ToArray();
            }
            catch (InvalidCastException ic)
            {
                _logger.LogInformation($"Falhou tentativa de obter os clientes para iniciar a sincronização dos contratos. | {ic.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(ic.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(ic.Message);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter os clientes para iniciar a sincronização dos contratos. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }

            if (clientes == null || clientes.Count() <= 0)
            {
                _logger.LogInformation($"Nenhum cliente encontrado para iniciar a sincronização. | {clientes.Count()}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Nenhum cliente encontrado para iniciar a sincronização", rotinaEventHistoryId);
                throw new ArgumentNullException("Nenhum cliente encontrato para iniciar a sincronização com api de terceiro.");
            }
            #endregion

            #region Get contratos
            IEnumerable<ClienteContrato> contratos = new List<ClienteContrato>();
            try
            {
                contratos = await _clienteContratoRepository.GetAllAsync();
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter os contratos para iniciar a sincronização. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }
            #endregion

            #region Get data Bom Controle (Third Party)
            BCContratoModelService[] clienteContratosThirdParty;
            Int64 totalSincronizado = 0;
            var clientesContratos = new List<ClienteContrato>();
            try
            {
                for (var a = 0; a < clientes.Count(); a++)
                {
                    switch (clientes[a].TipoPessoa) {
                        case TipoPessoaEnum.FISICA:
                            clienteContratosThirdParty = await _bcServices.VendaContratoPesquisar(clientes[a].Cpf, token);
                            break;
                        case TipoPessoaEnum.JURIDICA:
                            clienteContratosThirdParty = await _bcServices.VendaContratoPesquisar(clientes[a].CNPJ, token);
                            break;
                        default:
                            clienteContratosThirdParty = null;
                            break;
                    }

                    if (clienteContratosThirdParty == null) continue;

                    for (var b = 0; b < clienteContratosThirdParty.Count(); b++)
                    {
                        // Verifico se o contrato obtido da api de terceiro já não existe na minha base
                        if (!contratos.Any(x => x.BomControleContratoId.Equals(clienteContratosThirdParty[b].Id)))
                        {
                            // contrato não existe, portanto, posso sincronizá-lo para minha base
                            var contratoMapped = new ClienteContrato();
                            try
                            {
                                contratoMapped = _mapper.Map<ClienteContrato>(clienteContratosThirdParty[b]);
                                contratoMapped.ClienteId = clientes[a].Id;
                            }
                            catch (InvalidCastException ic) { 
                                _logger.LogInformation($"Problemas no mapeamento do contrato do cliente para sincronização. | {ic.Message}");
                                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do cliente para sincronização", rotinaEventHistoryId);
                                throw new InvalidOperationException(ic.Message); 
                            }
                            catch (InvalidOperationException io) { 
                                _logger.LogInformation($"Problemas no mapemanento do cliente. | {io.Message}");
                                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do contrato do cliente", rotinaEventHistoryId);
                                throw new InvalidOperationException(io.Message); 
                            }
                            catch (Exception ex) { 
                                _logger.LogInformation($"Problemas no mapemanento do cliente. | {ex.Message}");
                                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas no mapeamento do contrato do cliente", rotinaEventHistoryId);
                                throw new InvalidOperationException(ex.Message); 
                            }

                            try
                            {
                                clientesContratos.Add(contratoMapped);
                                totalSincronizado++;   
                            }
                            catch (InvalidOperationException io) { 
                                _logger.LogInformation($"Problemas ao adicionar contrato de cliente. | {io.Message}");
                                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao adicionar contrato cliente", rotinaEventHistoryId);
                                throw new InvalidOperationException(io.Message);
                            }
                        }
                    }
                }
            }
            catch (InvalidOperationException ex) { 
                _logger.LogInformation($"Problemas ao efetuar sincronização dos contratos de clientes a partir da api de terceiro. | {ex.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao efetuar sincronização dos contratos de clientes a partir da api de terceiro", rotinaEventHistoryId);
                throw new InvalidOperationException(ex.Message); 
            }
            #endregion

            #region Persistance
            try
            {
                await _clienteContratoRepository.AddRangeAsync(clientesContratos);
            }
            catch (InvalidOperationException io) {
                _logger.LogInformation($"Problemas ao adicionar os contratos. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new InvalidOperationException(io.Message); 
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

            #region Get contratos
            ClienteContrato[] clientesContratos;
            try
            {
                clientesContratos = _clienteContratoRepository.GetAll().ToArray();
            }
            catch (InvalidCastException ic)
            {
                _logger.LogInformation($"Falhou tentativa de obter os contratos de clientes para iniciar as atualizações. | {ic.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(ic.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(ic.Message);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de obter os contratos de clientes para iniciar as atualizações. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle(io.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(io.Message);
            }

            if (clientesContratos == null || clientesContratos.Count() <= 0)
            {
                _logger.LogInformation($"Nenhum contrato de cliente encontrado para iniciar a atualização. | {clientesContratos.Count()}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Nenhum contrato de cliente encontrado para iniciar a sincronização", rotinaEventHistoryId);
                throw new ArgumentNullException("Nenhum contrato de cliente encontrato para iniciar a sincronização com api de terceiro.");
            }
            #endregion

            #region Obtém os contratos da Api Terceiro um a um e atualiza a periodicidade no BoxApp
            var contratoFromThirdParty = new BCContratoModelService();
            Int64 totalContratosAtualizados = 0;
            try
            {
                for (var i = 0; i <  clientesContratos.Count(); i++)
                {
                    try
                    {
                        contratoFromThirdParty = await _bcServices.VendaContratoObter((long)clientesContratos[i].BomControleContratoId, false, token);
                    }
                    catch (Refit.ApiException ex) { 
                        if (ex.HasContent) continue;
                    }
                    
                    if (contratoFromThirdParty != null)
                    {
                        if (clientesContratos[i].Periodicidade != contratoFromThirdParty.Periodicidade)
                        {
                            clientesContratos[i].Periodicidade = contratoFromThirdParty.Periodicidade;

                            try
                            {
                                _clienteContratoRepository.Update(clientesContratos[i]);
                                totalContratosAtualizados++;
                            }
                            catch (InvalidOperationException io) { 
                                _logger.LogInformation($"Problemas ao efetuar atualização dos dados de contratos dos clientes a partir da api de terceiro. | {io.Message}");
                                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao efetuar sincronização dos clientes a partir da api de terceiro", rotinaEventHistoryId);
                                throw new InvalidOperationException(io.Message); 
                            }
                            
                        } else continue;
                    } else continue;
                }
            }
            catch (InvalidOperationException io) { 
                _logger.LogInformation($"Problemas ao efetuar atualização dos dados de contratos dos clientes a partir da api de terceiro. | {io.Message}");
                _rotinaEventHistoryService.UpdateWithStatusFalhaExecucaoHandle("Problemas ao efetuar sincronização dos clientes a partir da api de terceiro", rotinaEventHistoryId);
                throw new InvalidOperationException(io.Message); 
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
                _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalContratosAtualizados, 0);
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
            _clienteContratoRepository.Dispose();
        }
    }
}