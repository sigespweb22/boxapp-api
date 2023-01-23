using System;
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
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.ServicesThirdParty;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/clientes-produtos")]
    public class ClienteProdutoEndpoint : ApiController
    {
        private readonly ICNPJAServices _cnpjaServices;
        private readonly IBCServices _bcServices;
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public ClienteProdutoEndpoint(BoxAppDbContext context,
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
        /// Lista de todos os PRODUTOS de um cliente
        /// </summary>
        /// <param name="q"></param>
        /// <param name="clienteId"></param>
        /// <returns>Um json com os PRODUTOS do cliente</returns>
        /// <response code="200">Lista de PRODUTOS do cliente</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteProdutoList, CanClienteProdutoAll, CanClienteAll")]
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
                AddError("Id Cliente requerido.");
                return CustomResponse(400);
            }

            #region Get data
            var clienteProdutos = new List<ClienteProduto>();
            try
            {
                clienteProdutos = await _context.ClientesProdutos
                                                    .AsNoTracking()
                                                    .Include(x => x.Produto)
                                                    .Where(x => x.ClienteId == Guid.Parse(clienteId))
                                                    .OrderByDescending(x => x.UpdatedAt)
                                                    .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clienteProdutos == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search 
            if(!string.IsNullOrEmpty(q))
                clienteProdutos = clienteProdutos.Where(x => x.Nome.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<ClienteProdutoViewModel> clienteProdutoMapped = new List<ClienteProdutoViewModel>();
            try
            {
                clienteProdutoMapped = _mapper.Map<IEnumerable<ClienteProdutoViewModel>>(clienteProdutos);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = clienteProdutoMapped.ToList(),
                clienteProdutos = clienteProdutoMapped.ToList(),
                Params = q,
                Total = clienteProdutoMapped.Count()
            });
        }

        /// <summary> 
        /// Adiciona um PRODUTO para um cliente
        /// </summary>
        /// <param name="clienteProdutoViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Master, CanClienteProdutoCreate, CanClienteProdutoAll, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ClienteProdutoViewModel clienteProdutoViewModel)
        {
            #region Map
            var clienteProdutoMapped = new ClienteProduto();
            try
            {
                clienteProdutoMapped = _mapper.Map<ClienteProduto>(clienteProdutoViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            clienteProdutoMapped.Produto = null;
            #endregion

            #region Persistance and commit
            try
            {
                await _context.ClientesProdutos.AddAsync(clienteProdutoMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CreatedAtAction(null, new { clienteId = clienteProdutoViewModel.ClienteId});
        }

        /// <summary>
        /// Atualiza o PRODUTO de um cliente
        /// </summary>
        /// <param name="ClienteProdutoViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteProdutoUpdate, CanClienteProdutoAll, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ClienteProdutoViewModel ClienteProdutoViewModel)
        {
            #region Required validations
            if (!ClienteProdutoViewModel.Id.HasValue ||
                ClienteProdutoViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var clienteProdutoDB = new ClienteProduto();
            try
            {
                clienteProdutoDB = await _context
                                            .ClientesProdutos
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id == ClienteProdutoViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (clienteProdutoDB == null)
            {
                AddError("Serviço de cliente não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var clienteProdutoMap = new ClienteProduto();
            try
            {
                clienteProdutoMap = _mapper.Map<ClienteProdutoViewModel, ClienteProduto>(ClienteProdutoViewModel, clienteProdutoDB);
                clienteProdutoMap.Cliente = null;
                clienteProdutoMap.Produto = null;
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update serviço cliente
            try
            {
                _context.ClientesProdutos.Update(clienteProdutoMap);
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

            return CustomResponse(200, new { clienteId = ClienteProdutoViewModel.ClienteId } );
        }

        /// <summary>
        /// Altera o status de um PRODUTO de um cliente
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
        
        [Authorize(Roles = "Master, CanClienteProdutoUpdate, CanClienteProdutoAll, CanClienteAll")]
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
            var clienteProduto = new ClienteProduto();
            try
            {
                clienteProduto = await _context.ClientesProdutos.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (clienteProduto == null)
            {
                AddError("Produto do cliente não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(clienteProduto.IsDeleted)
            {
                case true:
                    clienteProduto.IsDeleted = false;
                    break;
                case false:
                    clienteProduto.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.ClientesProdutos.Update(clienteProduto);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(200, new { message = "Status produto do cliente alterado com sucesso.", clienteId = clienteProduto.ClienteId } );
        }

        /// <summary>
        /// Retorna um PRODUTO de CLIENTE pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto com o PRODUTO solicitado</returns>
        /// <response code="200">Lista um PRODUTO de CLIENTE</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">PRODUTO não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteProdutoRead, CanClienteProdutoAll, CanClienteAll")]
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
            var clienteProduto = new ClienteProduto();
            try
            {
                clienteProduto = await _context.ClientesProdutos
                                                .FindAsync(Guid.Parse(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clienteProduto == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var clienteProdutoMapped = new ClienteProdutoViewModel();
            try
            {
                clienteProdutoMapped = _mapper.Map<ClienteProdutoViewModel>(clienteProduto);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = clienteProdutoMapped,
                ClienteProduto = clienteProdutoMapped,
                Params = id
            });
        }
    }
}