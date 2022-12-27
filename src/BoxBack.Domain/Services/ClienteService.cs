using System;
using System.Linq;
using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.InterfacesRepositories;
using System.Collections.Generic;
using BoxBack.Domain.ModelsServices;
using BoxBack.Domain.ServicesThirdParty;
using BoxBack.Domain.InterfacesRepositories;
using AutoMapper;

namespace BoxBack.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IChaveApiTerceiroRepository _chaveApiTerceiroRepository;
        private readonly IRotinaEventHistoryRepository _rotinaEventHistoryRepository;
        private readonly IRotinaRepository _rotinaRepository;
        private readonly IBCServices _bcServices;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public ClienteService(IClienteRepository clienteRepository,
                              IChaveApiTerceiroRepository chaveApiTerceiroRepository,
                              IRotinaEventHistoryRepository rotinaEventHistoryRepository,
                              IRotinaRepository rotinaRepository,
                              IBCServices bcServices,
                              IMapper mapper,
                              IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _chaveApiTerceiroRepository = chaveApiTerceiroRepository;
            _rotinaEventHistoryRepository = rotinaEventHistoryRepository;
            _rotinaRepository = rotinaRepository;
            _bcServices = bcServices;
            _unitOfWork = unitOfWork;
        }
    
        public async Task SincronizarFromTPAsync(string token)
        {
            #region Get data Bom Controle (TP)
            IEnumerable<BCClienteModelService> clientesThirdParty = new List<BCClienteModelService>();
            try
            {
                clientesThirdParty = await _bcServices.ClientePesquisar(token);
            }
            catch (Exception e) when (e is FormatException or OverflowException) { throw e; }

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
            catch (Exception ex) { throw new InvalidOperationException(ex.Message); }
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
                    catch (Exception ex) { throw new InvalidOperationException(ex.Message); }
                    
                    try
                    {
                        if (cliente.Id != Guid.Empty)
                        {
                            await _clienteRepository.AddAsync(cliente);
                            totalSincronizado++;
                        }
                    }
                    catch (Exception ex) { throw new InvalidOperationException(ex.Message); }
                }
            }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex) { throw new InvalidOperationException(ex.Message); }
            #endregion
            await Task.Run(() => "1");
        }
    }
}