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
using Microsoft.Extensions.DependencyInjection;

namespace BoxBack.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ILogger _logger;
        private readonly IClienteRepository _clienteRepository;
        private readonly IChaveApiTerceiroRepository _chaveApiTerceiroRepository;
        private readonly IRotinaEventHistoryRepository _rotinaEventHistoryRepository;
        private readonly IRotinaRepository _rotinaRepository;
        private readonly IBCServices _bcServices;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRotinaEventHistoryService _rotinaEventHistoryService;
        
        public ClienteService(ILogger<ClienteService> logger,
                              IClienteRepository clienteRepository,
                              IChaveApiTerceiroRepository chaveApiTerceiroRepository,
                              IRotinaEventHistoryRepository rotinaEventHistoryRepository,
                              IRotinaRepository rotinaRepository,
                              IBCServices bcServices,
                              IMapper mapper,
                              IUnitOfWork unitOfWork,
                              IRotinaEventHistoryService rotinaEventHistoryService)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
            _chaveApiTerceiroRepository = chaveApiTerceiroRepository;
            _rotinaEventHistoryRepository = rotinaEventHistoryRepository;
            _rotinaRepository = rotinaRepository;
            _bcServices = bcServices;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _rotinaEventHistoryService = rotinaEventHistoryService;
        }
    
        public async Task SincronizarFromTPAsync(string token, Guid rotinaEventHistoryId)
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
        public async Task SyncAsync(string token, Guid rotinaEventHistoryId, IServiceScope scope)
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
                var teste = scope.ServiceProvider.GetService<IClienteRepository>().GetAllAsync();    
            }
            catch (System.Exception)
            {
                
                throw;
            }
            var _scopeClienteRepository = scope.ServiceProvider.GetService<IClienteRepository>();
            try
            {
                clientesBoxApp = await _scopeClienteRepository.GetAllAsync();
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
                            await _scopeClienteRepository.AddAsync(cliente);
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
                var _scopeUnitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>();
                _scopeUnitOfWork.Commit();
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
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAllAsync();
        }
        
        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}