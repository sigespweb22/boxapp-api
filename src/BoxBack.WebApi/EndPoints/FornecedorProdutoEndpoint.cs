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
using BoxBack.Domain.ModelsServices;
using BoxBack.Application.ViewModels.Selects;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/fornecedores-produtos")]
    public class FornecedorProdutoEndpoint : ApiController
    {
        private readonly ICNPJAServices _cnpjaServices;
        private readonly IBCServices _bcServices;
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public FornecedorProdutoEndpoint(BoxAppDbContext context,
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
        /// Lista de todos os PRODUTOS de um FORNECEDOR
        /// </summary>
        /// <param name="q"></param>
        /// <param name="fornecedorId"></param>
        /// <returns>Um array json com os PRODUTOS de um FORNECEDOR</returns>
        /// <response code="200">Lista de PRODUTOS de um FORNECEDOR</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorProdutoList, CanFornecedorProdutoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q, string fornecedorId)
        {
            if (string.IsNullOrEmpty(fornecedorId))
            {
                AddError("Id do Fornecedor requerido.");
                return CustomResponse(400);
            }

            #region Get data
            var fornecedorProdutos = new List<FornecedorProduto>();
            try
            {
                fornecedorProdutos = await _context.FornecedorProdutos
                                                        .AsNoTracking()
                                                        .Where(x => x.FornecedorId == Guid.Parse(fornecedorId))
                                                        .OrderByDescending(x => x.UpdatedAt)
                                                        .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (fornecedorProdutos == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search 
            if(!string.IsNullOrEmpty(q))
                fornecedorProdutos = fornecedorProdutos.Where(x => x.Nome.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<FornecedorProdutoViewModel> fornecedorProdutoMapped = new List<FornecedorProdutoViewModel>();
            try
            {
                fornecedorProdutoMapped = _mapper.Map<IEnumerable<FornecedorProdutoViewModel>>(fornecedorProdutos);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = fornecedorProdutoMapped.ToList(),
                FornecedorProdutos = fornecedorProdutoMapped.ToList(),
                Params = q,
                Total = fornecedorProdutoMapped.Count()
            });
        }

        /// <summary>
        /// Lista todos os PRODUTOS de FORNECEDORES para uma select
        /// </summary>
        /// <param name="q"></param>
        /// <param name="isDeleted"></param>
        /// <returns>Um array json com os PRODUTOS de FORNECEDORES</returns>
        /// <response code="200">Lista de PRODUTOS de FORNECEDORES</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorProdutoList, CanFornecedorProdutoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q, bool isDeleted = false)
        {
            #region Get data
            var fornecedorProdutoDB = new List<FornecedorProduto>();
            try
            {
                fornecedorProdutoDB = await _context
                                                .FornecedorProdutos
                                                .AsNoTracking()
                                                .Where(x => !x.IsDeleted || x.IsDeleted == isDeleted)
                                                .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (fornecedorProdutoDB == null)
            {
                AddError("Não encontrado");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            IEnumerable<FornecedorProdutoSelect2ViewModel> fornecedorProdutoMap = new List<FornecedorProdutoSelect2ViewModel>();
            try
            {
                fornecedorProdutoMap = _mapper.Map<IEnumerable<FornecedorProdutoSelect2ViewModel>>(fornecedorProdutoDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(fornecedorProdutoMap);
        }

        /// <summary> 
        /// Adiciona um PRODUTO para um FORNECEDOR
        /// </summary>
        /// <param name="fornecedorProdutoViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorProdutoCreate, CanFornecedorProdutoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]FornecedorProdutoViewModel fornecedorProdutoViewModel)
        {
            #region Map
            var fornecedorProdutoMapped = new FornecedorProduto();
            try
            {
                fornecedorProdutoMapped = _mapper.Map<FornecedorProduto>(fornecedorProdutoViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            fornecedorProdutoMapped.Fornecedor = null;
            #endregion

            #region Persistance and commit
            try
            {
                await _context.FornecedorProdutos.AddAsync(fornecedorProdutoMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CreatedAtAction(null, new { fornecedorId = fornecedorProdutoViewModel.FornecedorId});
        }

        /// <summary>
        /// Atualiza o SERVIÇO de um FORNECEDOR
        /// </summary>
        /// <param name="fornecedorProdutoViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorProdutoUpdate, CanFornecedorProdutoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]FornecedorProdutoViewModel fornecedorProdutoViewModel)
        {
            #region Required validations
            if (!fornecedorProdutoViewModel.Id.HasValue ||
                fornecedorProdutoViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var fornecedorProdutoDB = new FornecedorProduto();
            try
            {
                fornecedorProdutoDB = await _context
                                                .FornecedorProdutos
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(x => x.Id.Equals(fornecedorProdutoViewModel.Id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (fornecedorProdutoDB == null)
            {
                AddError("Produto do fornecedor não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var fornecedorProdutoMap = new FornecedorProduto();
            try
            {
                fornecedorProdutoMap = _mapper.Map<FornecedorProdutoViewModel, FornecedorProduto>(fornecedorProdutoViewModel, fornecedorProdutoDB);
                fornecedorProdutoMap.Fornecedor = null;
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update produto
            try
            {
                _context.FornecedorProdutos.Update(fornecedorProdutoMap);
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

            return CustomResponse(200, new { fornecedorId = fornecedorProdutoViewModel.FornecedorId } );
        }

        /// <summary>
        /// Altera o status do PRODUTO de um FORNECEDOR
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
        [Authorize(Roles = "Master, CanFornecedorProdutoUpdate, CanFornecedorProdutoAll, CanFornecedorAll")]
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
            var fornecedorProduto = new FornecedorProduto();
            try
            {
                fornecedorProduto = await _context.FornecedorProdutos.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (fornecedorProduto == null)
            {
                AddError("Produto do fornecedor não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(fornecedorProduto.IsDeleted)
            {
                case true:
                    fornecedorProduto.IsDeleted = false;
                    break;
                case false:
                    fornecedorProduto.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.FornecedorProdutos.Update(fornecedorProduto);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status do produto do fornecedor alterado com sucesso.", fornecedorId = fornecedorProduto.FornecedorId } );
        }

        /// <summary>
        /// Retorna um PRODUTO de FORNECEDOR pelo seu Id
        /// </summary>
        /// <param name="fornecedorId"></param>
        /// <returns>Um objeto com o PRODUTO do FORNECEDOR</returns>
        /// <response code="200">Lista um PRODUTO de um FORNECEDOR</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">PRODUTO de FORNECEDOR não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanFornecedorProdutoRead, CanFornecedorProdutoAll, CanFornecedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> ListOneAsync([FromRoute]Guid? fornecedorId)
        {
            #region Required validations
            if (!fornecedorId.HasValue || fornecedorId == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var fornecedorProduto = new FornecedorProduto();
            try
            {
                fornecedorProduto = await _context.FornecedorProdutos
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync(x => x.FornecedorId.Equals(fornecedorId));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (fornecedorProduto == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var fornecedorProdutoMapped = new FornecedorProdutoViewModel();
            try
            {
                fornecedorProdutoMapped = _mapper.Map<FornecedorProdutoViewModel>(fornecedorProduto);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = fornecedorProdutoMapped,
                FornecedorProduto = fornecedorProdutoMapped,
                Params = fornecedorId
            });
        }
    }
}