﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Infra.Data.Context;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using AutoMapper;
using BoxBack.Domain.Interfaces;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.Services;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/clientes-servicos")]
    public class ClienteServicoEndpoint : ApiController
    {
        private readonly ICNPJAServices _cnpjaServices;
        private readonly IBCServices _bcServices;
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public ClienteServicoEndpoint(BoxAppDbContext context,
                                      IUnitOfWork unitOfWork,
                                      UserManager<ApplicationUser> manager, 
                                      RoleManager<ApplicationRole> roleManager,
                                      IMapper mapper,
                                      ICNPJAServices cnpjaServices,
                                      IBCServices bcServices)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
            _cnpjaServices = cnpjaServices;
            _bcServices = bcServices;
        }

        /// <summary>
        /// Lista de todos os serviços ativos de um cliente
        /// </summary>s
        /// <param name="q"></param>
        /// <param name="clienteId"></param>
        /// <returns>Um json com os serviços do cliente</returns>
        /// <response code="200">Lista de serviços do cliente</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteServicoList, CanClienteServicoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q, string clienteId)
        {
            if (string.IsNullOrEmpty(clienteId))
            {
                AddError("ClienteId requerido.");
                return CustomResponse(400);
            }

            #region Get data
            var clienteServicos = new List<ClienteServico>();
            try
            {
                clienteServicos = await _context.ClientesServicos
                                                .AsNoTracking()
                                                .Include(x => x.Servico)
                                                .Where(x => x.ClienteId == Guid.Parse(clienteId))
                                                .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clienteServicos == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                clienteServicos = clienteServicos.Where(x => x.Nome.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<ClienteServicoViewModel> clienteServicoMapped = new List<ClienteServicoViewModel>();
            try
            {
                clienteServicoMapped = _mapper.Map<IEnumerable<ClienteServicoViewModel>>(clienteServicos);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = clienteServicoMapped.ToList(),
                ClientesServicos = clienteServicoMapped.ToList(),
                Params = q,
                Total = clienteServicoMapped.Count()
            });
        }

        /// <summary> 
        /// Adiciona um serviço para um
        /// </summary>
        /// <param name="clienteServicoViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Master, CanClienteServicoCreate, CanClienteServicoAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ClienteServicoViewModel clienteServicoViewModel)
        {
            #region Map
            var clienteServicoMapped = new ClienteServico();
            try
            {
                clienteServicoMapped = _mapper.Map<ClienteServico>(clienteServicoViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.ClientesServicos.AddAsync(clienteServicoMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanClientUpdate, CanClientAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ClienteViewModel clienteViewModel)
        {
            #region Required validations
            if (clienteViewModel.Id == null ||
                clienteViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var clienteDB = new Cliente();
            try
            {
                clienteDB = await _context
                                    .Clientes
                                    .FindAsync(clienteViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (clienteDB == null)
            {
                AddError("Cliente não encontrada para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var clienteMap = new Cliente();
            try
            {
                clienteMap = _mapper.Map<ClienteViewModel, Cliente>(clienteViewModel, clienteDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update cliente
            try
            {
                _context.Clientes.Update(clienteMap);
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

            return CustomResponse(204);
        }

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        [Route("delete/{id}")]
        [Authorize(Roles = "Master, CanClientDelete, CanClientAll")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            #region Validations required
            if (id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Generals validations
            // implementar
            #endregion

            #region Get data
            var cliente = new Cliente();
            try
            {
                cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    AddError("Cliente não encontrado para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete
            try
            {
                _context.Clientes.Remove(cliente);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se a operação foi realizada com sucesso</returns>
        /// <response code="200">Status alterado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /alter-status
        ///     {
        ///        "id": "f9c7d5a6-1181-4591-948b-5f97088e20a4"
        ///     }
        ///
        /// </remarks>
        [Route("alter-status/{id}")]
        [Authorize(Roles = "Master, CanClientAlterStatus, CanClientAll")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
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
            var cliente = new Cliente();
            try
            {
                cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    AddError("Cliente não encontrado para alterar seu status.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Map
            switch(cliente.IsDeleted)
            {
                case true:
                    cliente.IsDeleted = false;
                    break;
                case false:
                    cliente.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.Clientes.Update(cliente);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status cliente alterado com sucesso." } );
        }

        /// <summary>
        /// Retorna um cliente pelo seu Id
        /// </summary>s
        /// <param name="id"></param>
        /// <returns>Um objeto com o cliente solicitado</returns>
        /// <response code="200">Lista um cliente</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Cliente não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClientListOne, CanClientAll")]
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
            var cliente = new Cliente();
            try
            {
                cliente = await _context.Clientes
                                            .FindAsync(Guid.Parse(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (cliente == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var clienteMapped = new ClienteViewModel();
            try
            {
                clienteMapped = _mapper.Map<ClienteViewModel>(cliente);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = clienteMapped,
                Cliente = clienteMapped,
                Params = id
            });
        }

        #region Third Party

        /// <summary>
        /// Lista os dados do CNPJ de uma empresa a partir de uma api de terceiro
        /// </summary>s
        /// <param name="cnpj"></param>
        /// <returns>Um json com os dados da empresa</returns>
        /// <response code="200">Dados da empresa</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">CNPJ não encontrado</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /tp
        ///     {
        ///        "cnpj": "23831562000182"
        ///     }
        ///
        /// </remarks>
        [Route("tp/{cnpj}")]
        [Authorize(Roles = "Master, CanCnpjTPListOne, CanCnpjTPAll")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> GetByApiThirdPartyByCnpj(string cnpj)
        {
            #region Required validations
            if (string.IsNullOrEmpty(cnpj))
            {
                AddError("CNPJ requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var empresa = new CNPJaEmpresaModelService();
            try
            {
                empresa = await _cnpjaServices.ConsultaEstabelecimento(cnpj);
                if (empresa == null)
                {
                    AddError("Empresa não encontrada com o CNPJ informado.");
                    return CustomResponse(404, empresa);
                }
            }
            catch (Exception Content) { AddErrorToTryCatch(Content); return CustomResponse(400); }
            #endregion
            
            return CustomResponse(200, empresa);
        }
        #endregion
    }
}