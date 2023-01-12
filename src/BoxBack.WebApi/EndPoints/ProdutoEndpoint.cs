using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Infra.Data.Context;
using AutoMapper;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.Models;
using BoxBack.Application.ViewModels;
using BoxBack.Application.ViewModels.Selects;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/produtos")]
    public class ProdutoEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProdutoEndpoint(BoxAppDbContext context,
                               IUnitOfWork unitOfWork,
                               IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os PRODUTOS
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com os PRODUTOS</returns>
        /// <response code="200">Lista de PRODUTOS</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanProdutoList, CanProdutoAll, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q)
        {
            #region Get data
            var produtos = new List<Produto>();
            try
            {
                produtos = await _context.Produtos
                                            .AsNoTracking()
                                            .Include(x => x.FornecedorProduto)
                                            .OrderByDescending(x => x.UpdatedAt)
                                            .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (produtos == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                produtos = produtos.Where(x => x.Nome.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<ProdutoViewModel> produtosMapped = new List<ProdutoViewModel>();
            try
            {
                produtosMapped = _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = produtosMapped.ToList(),
                Produtos = produtosMapped.ToList(),
                Params = q,
                Total = produtosMapped.Count()
            });
        }

        /// <summary>
        /// Lista todos os PRODUTOS para uma select2
        /// </summary>
        /// <param name="q"></param>
        /// <param name="isDeleted"></param>
        /// <returns>Um json com os PRODUTOS</returns>
        /// <response code="200">Lista de PRODUTOS</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanProdutoList, CanProdutoAll, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("list-to-select")]
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q, bool isDeleted = false)
        {
            #region Get data
            var produtosDB = new List<Produto>();
            try
            {
                produtosDB = await _context
                                        .Produtos
                                        .Where(x => !x.IsDeleted || x.IsDeleted == isDeleted)
                                        .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (produtosDB == null)
            {
                AddError("Não encontrado");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            IEnumerable<ProdutoSelect2ViewModel> produtosMap = new List<ProdutoSelect2ViewModel>();
            try
            {
                produtosMap = _mapper.Map<IEnumerable<ProdutoSelect2ViewModel>>(produtosDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(produtosMap);
        }

        /// <summary>
        /// Cria um PRODUTO
        /// </summary>
        /// <param name="produtoViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanProdutoCreate, CanProdutoAll, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status201Created)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ProdutoViewModel produtoViewModel)
        {
            #region Map
            var produtoMapped = new Produto();
            try
            {
                produtoMapped = _mapper.Map<Produto>(produtoViewModel);
                produtoMapped.FornecedorProduto = null;
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.Produtos.AddAsync(produtoMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza um PRODUTOS
        /// </summary>
        /// <param name="produtoViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanProdutoUpdate, CanProdutoAll, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ProdutoViewModel produtoViewModel)
        {
            #region Required validations
            if (!produtoViewModel.Id.HasValue ||
                produtoViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var produtoDB = new Produto();
            try
            {
                produtoDB = await _context
                                    .Produtos
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Id == produtoViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (produtoDB == null)
            {
                AddError("Produto não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var produtoMap = new Produto();
            try
            {
                produtoMap = _mapper.Map<ProdutoViewModel, Produto>(produtoViewModel, produtoDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update
            try
            {
                _context.Produtos.Update(produtoMap);
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
        /// Deleta um PRODUTO
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Erro desconhecido</response>
        [Route("delete/{id}")]
        [Authorize(Roles = "Master, CanProdutoDelete, CanProdutoAll, CanClienteAll")]
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
            var produto = new Produto();
            try
            {
                produto = await _context.Produtos.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (produto == null)
            {
                AddError("Produto não encontrado para deletar.");
                return CustomResponse(404);
            }
            #endregion

            #region Delete
            try
            {
                _context.Produtos.Remove(produto);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de um PRODUTO
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se a operação foi realizada com sucesso</returns>
        /// <response code="200">Status alterado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Erro desconhecido</response>
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
        [Authorize(Roles = "Master, CanProdutoUpdate, CanProdutoAll, CanClienteAll")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            var produto = new Produto();
            try
            {
                produto = await _context.Produtos.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (produto == null)
            {
                AddError("Produto não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(produto.IsDeleted)
            {
                case true:
                    produto.IsDeleted = false;
                    break;
                case false:
                    produto.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.Produtos.Update(produto);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status produto alterado com sucesso." } );
        }
    }
}