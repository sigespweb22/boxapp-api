using System.Net.Mail;
using Microsoft.Win32;
using System.Net;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using System.Net.Sockets;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Infra.Data.Context;
using BoxBack.WebApi.Extensions;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Enums;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels.Selects;
using BoxBack.Infra.Data.Extensions;
using BoxBack.WebApi.Controllers;
using BoxBack.Application.ViewModels.Requests;
using BoxBack.Domain.Services;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.WebApi.EndPoints.User
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/clientes")]
    public class ClienteEndpoint : ApiController
    {
        private readonly ICNPJAServices _cnpjaServices;
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public ClienteEndpoint(BoxAppDbContext context,
                               IUnitOfWork unitOfWork,
                               UserManager<ApplicationUser> manager, 
                               RoleManager<ApplicationRole> roleManager, 
                               IMapper mapper,
                               ICNPJAServices cnpjaServices)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
            _cnpjaServices = cnpjaServices;
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>s
        /// <param name="q"></param>
        /// <returns>Um json com os clientes</returns>
        /// <response code="200">Lista de clientes</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanClienteList, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q)
        {
            #region Get data
            var clientes = new List<Cliente>();
            try
            {
                clientes = await _context.Clientes
                                            .AsNoTracking()
                                            .OrderBy(x => x.UpdatedAt)
                                            .ToListAsync();
                if (clientes == null)
                {
                    AddError("Não encontrado.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                clientes = clientes.Where(x => x.NomeFantasia.Contains(q.ToUpper())).ToList();
            #endregion

            #region Map
            IEnumerable<ClienteViewModel> clienteMapped = new List<ClienteViewModel>();
            try
            {
                clienteMapped = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = clienteMapped.ToList(),
                Users = clienteMapped.ToList(),
                Params = q,
                Total = clienteMapped.Count()
            });
        }

        /// <summary>
        /// Cria um cliente
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanClienteCreate, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ClienteViewModel clienteViewModel)
        {
            #region Map
            var clienteMapped = new Cliente();
            try
            {
                clienteMapped = _mapper.Map<Cliente>(clienteViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.Clientes.AddAsync(clienteMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(201);
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
        [Authorize(Roles = "Master, CanClienteDelete, CanClienteAll")]
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
        [Authorize(Roles = "Master, CanClienteAlterStatus, CanClienteAll")]
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
        /// Lista os dados de um cliente específico a partir de uma api de terceiro
        /// </summary>s
        /// <param name="cnpj"></param>
        /// <returns>Um json com os dados do cliente</returns>
        /// <response code="200">Dados do cliente</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Cliente não encontrado</response>
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
        [Authorize(Roles = "Master, CanClienteTPListOne, CanClienteTPAll")]
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
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return CustomResponse(200, empresa);
        }
    }
}