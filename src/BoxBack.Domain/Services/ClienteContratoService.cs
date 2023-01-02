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
        
        public ClienteContratoService(ILogger<ClienteContratoService> logger,
                                      IClienteContratoRepository clienteContratoRepository,
                                      IChaveApiTerceiroService chaveApiTerceiroService,
                                      IRotinaEventHistoryRepository rotinaEventHistoryRepository,
                                      IRotinaRepository rotinaRepository,
                                      IBCServices bcServices,
                                      IMapper mapper,
                                      IUnitOfWork unitOfWork,
                                      IRotinaEventHistoryService rotinaEventHistoryService)
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
        }
    
        public async Task SyncUpdateFromTPAsync(string token, Guid rotinaEventHistoryId)
        {
            #region Get data Bom Controle (TP)
            IEnumerable<BCClienteModelService> clientesThirdParty = new List<BCClienteModelService>();
            try
            {
                clientesThirdParty = await _bcServices.ClientePesquisar(token);
            }
            catch (Exception e) when (e is FormatException or OverflowException) { return; }

            if (clientesThirdParty == null || clientesThirdParty.Count() <= 0)
            {
                throw new ArgumentNullException("Nenhum registro encontrado na api de terceiro para seguir com a sincronização.");
            }
            #endregion

            #region Get data BoxApp
            IEnumerable<Cliente> clientesBoxApp = new List<Cliente>();
            try
            {
                clientesBoxApp = await _clienteRepository.GetAllAsync();
            }
            catch (InvalidOperationException ex) { throw new InvalidOperationException(ex.Message); }
            #endregion

            #region Sincronization
            Int64 totalSincronizado = 0;
            Int64 totalIsNotDocumento = 0;
            foreach (var clienteTP in clientesThirdParty)
            {
                bool clienteThirdPartyAlreadyInBoxApp = false;
                if (clienteTP.PessoaFisica == null)
                {
                    if (clienteTP.PessoaJuridica.Documento == null) totalIsNotDocumento++;

                    clienteThirdPartyAlreadyInBoxApp = clientesBoxApp.Any(x => x.CNPJ == clienteTP.PessoaJuridica.Documento);
                } else {
                    if (clienteTP.PessoaFisica.Documento == null) totalIsNotDocumento++;

                    clienteThirdPartyAlreadyInBoxApp = clientesBoxApp.Any(x => x.Cpf == clienteTP.PessoaFisica.Documento);
                }

                // Cliente não existe no BoxApp e está ativo no bom controle, portanto, deve ser cadastrado no BoxApp
                if (!clienteThirdPartyAlreadyInBoxApp && clienteTP.Bloqueado == false)
                {
                    var cliente = new Cliente();
                    try
                    {
                        if (clienteTP.TipoPessoa == "Juridica")
                        {
                            if (!string.IsNullOrEmpty(clienteTP.PessoaJuridica.Documento))
                            {
                                cliente = _mapper.Map<Cliente>(clienteTP);
                            }
                        } else {
                            if (!string.IsNullOrEmpty(clienteTP.PessoaFisica.Documento))
                            {
                                cliente = _mapper.Map<Cliente>(clienteTP);
                            }
                        }
                    }
                    catch (InvalidOperationException ex) { throw new InvalidOperationException(ex.Message); }
                    
                    try
                    {
                        if (cliente.Id != Guid.Empty)
                        {
                            await _clienteRepository.AddAsync(cliente);
                            totalSincronizado++;
                        }
                    }
                    catch (InvalidOperationException ex) { throw new InvalidOperationException(ex.Message); }
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
                throw new InvalidOperationException(io.Message); 
            }
            #endregion

            #region Create rotina event history of success
            try
            {
                _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalSincronizado, totalIsNotDocumento);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {io.Message}");
                throw new OperationCanceledException(io.Message, io.InnerException);
            }
            catch (ArgumentNullException an) 
            {
                _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {an.Message}");
                throw new OperationCanceledException(an.Message, an.InnerException);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {ex.Message}");
                throw new OperationCanceledException(ex.Message, ex.InnerException);
            }
            #endregion
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
                _rotinaEventHistoryAppService.UpdateWithStatusFalhaExecucaoHandle(ex.Message, rotinaEventHistoryId);
                throw new OperationCanceledException(ex.Message);
            }
            #endregion

            #region Get clientes
            Cliente[] clientes;
            try
            {
                clientes = await _context.Clientes.ToArrayAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clientes == null || clientes.Count() <= 0)
            {
                AddError("Nenhum cliente encontrado na base de dados, para então seguir com a sincronização dos contratos com o sistema de terceiro.");
                return CustomResponse(500);
            }
            #endregion

            #region Chave api resolve
            var chaveApiTerceiro = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiro = await _context
                                                .ChavesApiTerceiro
                                                .Where(x => x.DataValidade >= DateTimeOffset.Now &&
                                                       x.IsDeleted == false && !string.IsNullOrEmpty(x.Key))
                                                .FirstOrDefaultAsync(x => x.ApiTerceiro.Equals(ApiTerceiroEnum.BOM_CONTROLE));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (chaveApiTerceiro == null)
            { 
                AddError("Nenhuma chave de api de terceiro encontrada, verifique os possíveis erros: \n\nNenhuma chave de api cadastrada para esta integração. \n\nA chave de api cadastrada não possui uma Key. \n\nA chave de api cadastrada não está ativa. \n\nA chave de api cadastrada está com Data de Validade vencida.");
                return CustomResponse(404);
            }
            #endregion

            #region Token resolve
            String token = string.Empty;
            try
            {
                token = $"ApiKey {chaveApiTerceiro.Key}";
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Get contratos
            IEnumerable<ClienteContrato> contratos = new List<ClienteContrato>();
            try
            {
                contratos = await _context.ClientesContratos.ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
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
                                
                                clientesContratos.Add(contratoMapped);
                                totalSincronizado++;
                            }
                            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
                        }
                    }
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Persistance
            try
            {
                _context.ClientesContratos.AddRange(clientesContratos);    
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();    
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Return
            return CustomResponse(200, new {
                TotalSincronizado = totalSincronizado,
            });
            #endregion

             #region Create rotina event history of success
            try
            {
                _rotinaEventHistoryService.UpdateWithStatusConcluidaHandle(rotinaEventHistoryId, totalSincronizado, totalIsNotDocumento);
            }
            catch (InvalidOperationException io)
            {
                _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {io.Message}");
                throw new OperationCanceledException(io.Message, io.InnerException);
            }
            catch (ArgumentNullException an) 
            {
                _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {an.Message}");
                throw new OperationCanceledException(an.Message, an.InnerException);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Falhou tentativa de atualizar status da operação como concluída. | {ex.Message}");
                throw new OperationCanceledException(ex.Message, ex.InnerException);
            }
            #endregion
        }

        public async Task UpdateFromThirdPartyAsync(string token, Guid rotinaEventHistoryId)
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

            #region Get contratos
            ClienteContrato[] clientesContratos;
            try
            {
                clientesContratos = await _context.ClientesContratos.AsNoTracking().ToArrayAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clientesContratos == null || clientesContratos.Count() <= 0)
            {
                AddError("Nenhum contrato de cliente encontrado na base de dados, para então seguir com a atualização da periodicidade dos contratos a partir dos dados da api de terceiro.");
                return CustomResponse(500);
            }
            #endregion

            #region Chave api resolve
            var chaveApiTerceiro = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiro = await _context
                                                .ChavesApiTerceiro
                                                .Where(x => x.DataValidade >= DateTimeOffset.Now &&
                                                       x.IsDeleted == false && !string.IsNullOrEmpty(x.Key))
                                                .FirstOrDefaultAsync(x => x.ApiTerceiro.Equals(ApiTerceiroEnum.BOM_CONTROLE));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (chaveApiTerceiro == null)
            { 
                AddError("Nenhuma chave de api de terceiro encontrada, verifique os possíveis erros: \n\nNenhuma chave de api cadastrada para esta integração. \n\nA chave de api cadastrada não possui uma Key. \n\nA chave de api cadastrada não está ativa. \n\nA chave de api cadastrada está com Data de Validade vencida.");
                return CustomResponse(404);
            }
            #endregion

            #region Token resolve
            String token = string.Empty;
            try
            {
                token = $"ApiKey {chaveApiTerceiro.Key}";
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
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
                        contratoFromThirdParty = await _bcServices.VendaContratoObter((long)clientesContratos[i].BomControleContratoId, token);
                    }
                    catch (Refit.ApiException ex) { 
                        if (ex.HasContent) continue;
                    }
                    
                    if (contratoFromThirdParty != null)
                    {
                        if (clientesContratos[i].Periodicidade != contratoFromThirdParty.Periodicidade)
                        {
                            clientesContratos[i].Periodicidade = contratoFromThirdParty.Periodicidade;
                            _context.ClientesContratos.Update(clientesContratos[i]);
                            totalContratosAtualizados++;
                        } else continue;
                    } else continue;
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Return
            return CustomResponse(200, new {
                TotalContratosAtualizados = totalContratosAtualizados,
            });
            #endregion
        }
        public void Dispose()
        {
            _clienteContratoRepository.Dispose();
        }
    }
}