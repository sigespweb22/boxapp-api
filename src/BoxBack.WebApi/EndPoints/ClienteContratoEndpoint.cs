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
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.ServicesThirdParty;
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
    }
}