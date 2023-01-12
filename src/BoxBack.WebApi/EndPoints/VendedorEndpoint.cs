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
using BoxBack.Application.ViewModels;
using BoxBack.Application.ViewModels.Selects;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/vendedores")]
    public class VendedorEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBCServices _bcServices;

        public VendedorEndpoint(BoxAppDbContext context,
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
        /// Lista de todos os VENDEDORES
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um array json com os VENDEDORES</returns>
        /// <response code="200">Lista de VENDEDORES</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanVendedorList, CanVendedorAll")]
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
            var vendedores = new List<Vendedor>();
            try
            {
                vendedores = await _context.Vendedores
                                            .AsNoTracking()
                                            .Include(x => x.ApplicationUser)
                                            .OrderByDescending(x => x.UpdatedAt)
                                            .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (vendedores == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search 
            if(!string.IsNullOrEmpty(q))
            {
                try
                {
                    vendedores = vendedores.Where(x => x.Nome.Equals(q)).ToList();    
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            }
            #endregion

            #region Map
            IEnumerable<VendedorViewModel> vendedorMapped = new List<VendedorViewModel>();
            try
            {
                vendedorMapped = _mapper.Map<IEnumerable<VendedorViewModel>>(vendedores);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = vendedorMapped.ToList(),
                Vendedores = vendedorMapped.ToList(),
                Params = q,
                Total = vendedorMapped.Count()
            });
        }

        /// <summary> 
        /// Adiciona um VENDEDOR
        /// </summary>
        /// <param name="vendedorViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Master, CanVendedorCreate, CanVendedorAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]VendedorViewModel vendedorViewModel)
        {
            #region Map
            var vendedorMapped = new Vendedor();
            try
            {
                vendedorMapped = _mapper.Map<Vendedor>(vendedorViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.Vendedores.AddAsync(vendedorMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza o VENDEDOR
        /// </summary>
        /// <param name="vendedorViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanVendedorUpdate, CanVendedorAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]VendedorViewModel vendedorViewModel)
        {
            #region Required validations
            if (!vendedorViewModel.Id.HasValue ||
                vendedorViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var vendedorDB = new Vendedor();
            try
            {
                vendedorDB = await _context
                                            .Vendedores
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id == vendedorViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (vendedorDB == null)
            {
                AddError("Vendedor não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var vendedorMap = new Vendedor();
            try
            {
                vendedorMap = _mapper.Map<VendedorViewModel, Vendedor>(vendedorViewModel, vendedorDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update vendedor
            try
            {
                _context.Vendedores.Update(vendedorMap);
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
        /// Altera o status de um VENDEDOR
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
        [Authorize(Roles = "Master, CanVendedorUpdate, CanVendedorAll")]
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
            var vendedor = new Vendedor();
            try
            {
                vendedor = await _context.Vendedores.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (vendedor == null)
            {
                AddError("Vendedor não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(vendedor.IsDeleted)
            {
                case true:
                    vendedor.IsDeleted = false;
                    break;
                case false:
                    vendedor.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.Vendedores.Update(vendedor);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(200, new { message = "Status vendedor alterado com sucesso."} );
        }

        /// <summary>
        /// Retorna um VENDEDOR pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto com o VENDEDOR solicitado</returns>
        /// <response code="200">Lista um VENDEDOR</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">VENDEDOR não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanVendedorRead, CanVendedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            var vendedor = new Vendedor();
            try
            {
                vendedor = await _context.Vendedores
                                         .Include(x => x.ApplicationUser)
                                         .FirstOrDefaultAsync(x => x.Id.Equals(Guid.Parse(id)));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (vendedor == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var vendedorMapped = new VendedorViewModel();
            try
            {
                vendedorMapped = _mapper.Map<VendedorViewModel>(vendedor);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = vendedorMapped,
                Vendedor = vendedorMapped,
                Params = id
            });
        }

        /// <summary>
        /// Lista todos os VENDEDORES para uma select2
        /// </summary>
        /// <param name="q"></param>
        /// <param name="isDeleted"></param>
        /// <returns>Um array json com os VENDEDORES</returns>
        /// <response code="200">Lista de VENDEDORES</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanVendedorList, CanVendedorAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q, bool isDeleted = false)
        {
            #region Get data
            var vendedoresDB = new List<Vendedor>();
            try
            {
                vendedoresDB = await _context
                                        .Vendedores
                                        .Where(x => !x.IsDeleted || x.IsDeleted == isDeleted)
                                        .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (vendedoresDB == null)
            {
                AddError("Não encontrado");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            IEnumerable<VendedorSelect2ViewModel> vendedoresMap = new List<VendedorSelect2ViewModel>();
            try
            {
                vendedoresMap = _mapper.Map<IEnumerable<VendedorSelect2ViewModel>>(vendedoresDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(vendedoresMap);
        }
    }
}
