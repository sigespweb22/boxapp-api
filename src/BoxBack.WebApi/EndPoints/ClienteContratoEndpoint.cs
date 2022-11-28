using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Infra.Data.Context;
using BoxBack.Domain.Models;
using AutoMapper;
using BoxBack.Domain.Interfaces;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.Services;
using BoxBack.Domain.ModelsServices;
using BoxBack.Domain.Enums;
using BoxBack.Application.ViewModels;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/clientes-contratos")]
    public class ClienteContratoEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBCServices _bcServices;

        public ClienteContratoEndpoint(BoxAppDbContext context,
                                       IUnitOfWork unitOfWork,
                                       IMapper mapper,
                                       IBCServices bcServices)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bcServices = bcServices;
        }


        /// <summary>
        /// Lista de todos os CONTRATOS de um cliente
        /// </summary>
        /// <param name="q"></param>
        /// <param name="clienteId"></param>
        /// <returns>Um array json com os CONTRATOS do cliente</returns>
        /// <response code="200">Lista de CONTRATOS do cliente</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoList, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q, string clienteId)
        {
            #region Required validations
            if (string.IsNullOrEmpty(clienteId))
            {
                AddError("Id Cliente requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var clienteContratos = new List<ClienteContrato>();
            try
            {
                clienteContratos = await _context.ClientesContratos
                                                    .AsNoTracking()
                                                    .Where(x => x.ClienteId == Guid.Parse(clienteId))
                                                    .OrderByDescending(x => x.UpdatedAt)
                                                    .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clienteContratos == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search 
            if(!string.IsNullOrEmpty(q))
            {
                PeriodicidadeEnum query;
                Enum.TryParse<PeriodicidadeEnum>(q, out query);

                try
                {
                    clienteContratos = clienteContratos.Where(x => x.Periodicidade.Equals(query)).ToList();    
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            }
            #endregion

            #region Map
            IEnumerable<ClienteContratoViewModel> clienteContratoMapped = new List<ClienteContratoViewModel>();
            try
            {
                clienteContratoMapped = _mapper.Map<IEnumerable<ClienteContratoViewModel>>(clienteContratos);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = clienteContratoMapped.ToList(),
                clienteContratos = clienteContratoMapped.ToList(),
                Params = q,
                Total = clienteContratoMapped.Count()
            });
        }

        /// <summary> 
        /// Adiciona um CONTRATO para um cliente
        /// </summary>
        /// <param name="clienteContratoViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Master, CanClienteContratoCreate, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ClienteContratoViewModel clienteContratoViewModel)
        {
            #region Map
            var clienteContratoMapped = new ClienteContrato();
            try
            {
                clienteContratoMapped = _mapper.Map<ClienteContrato>(clienteContratoViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.ClientesContratos.AddAsync(clienteContratoMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CreatedAtAction(null, new { clienteId = clienteContratoViewModel.ClienteId});
        }

        /// <summary>
        /// Atualiza o CONTRATOS de um cliente
        /// </summary>
        /// <param name="clienteContratoViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoUpdate, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ClienteContratoViewModel clienteContratoViewModel)
        {
            #region Required validations
            if (!clienteContratoViewModel.Id.HasValue ||
                clienteContratoViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var clienteContratoDB = new ClienteContrato();
            try
            {
                clienteContratoDB = await _context
                                            .ClientesContratos
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id == clienteContratoViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (clienteContratoDB == null)
            {
                AddError("Serviço de cliente não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var clienteContratoMap = new ClienteContrato();
            try
            {
                clienteContratoMap = _mapper.Map<ClienteContratoViewModel, ClienteContrato>(clienteContratoViewModel, clienteContratoDB);
                clienteContratoMap.Cliente = null;
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update serviço cliente
            try
            {
                _context.ClientesContratos.Update(clienteContratoMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Check to result
            try
            {
                await _unitOfWork.CommitAsync(); 
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(200, new { clienteId = clienteContratoViewModel.ClienteId } );
        }

        /// <summary>
        /// Altera o status de um CONTRATO de um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se a operação foi realizada com sucesso</returns>
        /// <response code="200">Status alterado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Erro interno desconhecido</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /alter-status
        ///     {
        ///        "id": "f9c7d5a6-1181-4591-948b-5f97088e20a4"
        ///     }
        ///
        /// </remarks>
        
        [Authorize(Roles = "Master, CanClienteContratoUpdate, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("alter-status/{id}")]
        [HttpPut]
        public async Task<IActionResult> AlterStatusAsync(Guid id)
        {
            #region Validations required
            if (id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Get data
            var clienteContrato = new ClienteContrato();
            try
            {
                clienteContrato = await _context.ClientesContratos.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (clienteContrato == null)
            {
                AddError("Contrato do cliente não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(clienteContrato.IsDeleted)
            {
                case true:
                    clienteContrato.IsDeleted = false;
                    break;
                case false:
                    clienteContrato.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.ClientesContratos.Update(clienteContrato);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(200, new { message = "Status contrato do cliente alterado com sucesso.", clienteId = clienteContrato.ClienteId } );
        }

        /// <summary>
        /// Retorna um CONTRATO de CLIENTE pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto com o CONTRATO solicitado</returns>
        /// <response code="200">Lista um CONTRATO de CLIENTE</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">CONTRATO não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoRead, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> ListOneAsync([FromRoute]string id)
        {
            #region Required validations
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var clienteContrato = new ClienteContrato();
            try
            {
                clienteContrato = await _context.ClientesContratos
                                                .FindAsync(Guid.Parse(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clienteContrato == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var clienteContratoMapped = new ClienteContratoViewModel();
            try
            {
                clienteContratoMapped = _mapper.Map<ClienteContratoViewModel>(clienteContrato);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = clienteContratoMapped,
                ClienteContrato = clienteContratoMapped,
                Params = id
            });
        }

        #region Third party API
        /// <summary>
        /// Sincroniza a base de contratos de clientes do BOM CONTROLE com a base de contratos de clientes do BoxApp (Este método não atualiza os dados de contrato, apenas mantém os mesmos contratos em ambos os sistemas)
        /// </summary>
        /// <param></param>
        /// <returns>Um objeto com o total de contratos de clientes sincronizados</returns>
        /// <response code="200">Objeto com o total de clientes sincronizados</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Nenhum contrato encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoCreate, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("sincronizar-from-third-party")]
        [HttpGet]
        public async Task<IActionResult> SincronizarFromThirdPartyPAsync()
        {
            #region Get clientes
            IEnumerable<Cliente> clientes = new List<Cliente>();
            try
            {
                clientes = await _context.Clientes.ToListAsync();
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
            IEnumerable<BCContratoModelService> clienteContratosThirdParty = new List<BCContratoModelService>();
            Int64 totalSincronizado = 0;
            var clientesContratos = new List<ClienteContrato>();
            try
            {
                foreach (var cliente in clientes)
                {
                    switch (cliente.TipoPessoa) {
                        case TipoPessoaEnum.FISICA:
                            clienteContratosThirdParty = await _bcServices.VendaContratoPesquisar(cliente.Cpf, token);
                            break;
                        case TipoPessoaEnum.JURIDICA:
                            clienteContratosThirdParty = await _bcServices.VendaContratoPesquisar(cliente.CNPJ, token);
                            break;
                        default:
                            clienteContratosThirdParty = null;
                            break;
                    }

                    if (clienteContratosThirdParty == null) continue;

                    foreach (var clienteContratoThirdParty in clienteContratosThirdParty)
                    {
                        // Verifico se o contrato obtido da api de terceiro já não existe na minha base
                        if (!contratos.Any(x => x.BomControleContratoId.Equals(clienteContratoThirdParty.Id)))
                        {
                            // contrato não existe, portanto, posso sincronizá-lo para minha base
                            var contratoMapped = new ClienteContrato();
                            try
                            {
                                var clienteContratoThirdPartyId = clienteContratoThirdParty.Id;
                                clienteContratoThirdParty.Id = null;

                                contratoMapped = _mapper.Map<ClienteContrato>(clienteContratoThirdParty);
                                
                                contratoMapped.BomControleContratoId = clienteContratoThirdPartyId;
                                contratoMapped.ClienteId = cliente.Id;
                                
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
        }

        /// <summary>
        /// Atualiza a periodicidade dos contratos de clientes do BoxApp a partir da periodicidade dos mesmos contratos no BOM CONTROLE
        /// </summary>
        /// <param></param>
        /// <returns>Um objeto com o total de contratos atualizados</returns>
        /// <response code="200">Um objeto com o total de contratos atualizados</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Nenhum contrato encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteContratoUpdate, CanClienteContratoAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update-periodicidade-from-third-party")]
        [HttpGet]
        public async Task<IActionResult> UpdatePeriodicidadeFromThirdPartyPAsync()
        {
            #region Get contratos
            IEnumerable<ClienteContrato> clientesContratos = new List<ClienteContrato>();
            try
            {
                clientesContratos = await _context.ClientesContratos.AsNoTracking().ToListAsync();
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
                foreach (var clienteContrato in clientesContratos)
                {
                    contratoFromThirdParty = await _bcServices.VendaContratoObter((long)clienteContrato.BomControleContratoId, token);
                    if (contratoFromThirdParty != null)
                    {
                        if (clienteContrato.Periodicidade != contratoFromThirdParty.Periodicidade)
                        {
                            clienteContrato.Periodicidade = contratoFromThirdParty.Periodicidade;
                            _context.ClientesContratos.Update(clienteContrato);
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
        #endregion
    }
}