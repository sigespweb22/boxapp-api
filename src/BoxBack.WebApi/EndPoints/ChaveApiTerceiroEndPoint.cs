using System;
using System.Linq;
using System.Xml.Linq;
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
using BoxBack.Domain.Enums;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/chaves-api-terceiro")]
    public class ChaveApiTerceiroEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChaveApiTerceiroEndpoint(BoxAppDbContext context,
                                        IUnitOfWork unitOfWork,
                                        IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todas as CHAVES DE API TERCEIROS
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com as CHAVES DE API TERCEIROS</returns>
        /// <response code="200">Lista de CHAVES DE API TERCEIROS</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanChaveApiTerceiroList, CanChaveApiTerceiroAll")]
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
            var chavesApiTerceiro = new List<ChaveApiTerceiro>();
            try
            {
                chavesApiTerceiro = await _context.ChavesApiTerceiro
                                                    .IgnoreQueryFilters()
                                                    .AsNoTracking()
                                                    .OrderByDescending(x => x.UpdatedAt)
                                                    .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (chavesApiTerceiro == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
            {
                ApiTerceiroEnum param;
                Enum.TryParse<ApiTerceiroEnum>(q.ToUpper(), out param);
                
                chavesApiTerceiro = chavesApiTerceiro.Where(x => x.ApiTerceiro.Equals(param)).ToList();
            }
            #endregion

            #region Map
            IEnumerable<ChaveApiTerceiroViewModel> chavesApiTerceiroMapped = new List<ChaveApiTerceiroViewModel>();
            try
            {
                chavesApiTerceiroMapped = _mapper.Map<IEnumerable<ChaveApiTerceiroViewModel>>(chavesApiTerceiro);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = chavesApiTerceiroMapped.ToList(),
                ChavesApi = chavesApiTerceiroMapped.ToList(),
                Params = q,
                Total = chavesApiTerceiroMapped.Count()
            });
        }

        /// <summary>
        /// Lista todas as CHAVES DE API TERCEIROS para uma select
        /// </summary>
        /// <param name="q"></param>
        /// <param name="isDeleted"></param>
        /// <returns>Um json com as CHAVES DE API TERCEIROS</returns>
        /// <response code="200">Lista de CHAVES DE API TERCEIROS</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanChaveApiTerceiroList, CanChaveApiTerceiroAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("list-to-select")]
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q, bool isDeleted = false)
        {
            #region Get data
            var chavesApiTerceiroDB = new List<ChaveApiTerceiro>();
            try
            {
                chavesApiTerceiroDB = await _context
                                                .ChavesApiTerceiro
                                                .Where(x => !x.IsDeleted || x.IsDeleted == isDeleted)
                                                .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (chavesApiTerceiroDB == null)
            {
                AddError("Não encontrado");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            IEnumerable<ChaveApiTerceiroSelect2ViewModel> chaveApiTerceiroMap = new List<ChaveApiTerceiroSelect2ViewModel>();
            try
            {
                chaveApiTerceiroMap = _mapper.Map<IEnumerable<ChaveApiTerceiroSelect2ViewModel>>(chavesApiTerceiroDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(chaveApiTerceiroMap);
        }

        /// <summary>
        /// Cria uma CHAVE DE API TERCEIRO
        /// </summary>
        /// <param name="chaveApiTerceiroViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanChaveApiTerceiroCreate, CanChaveApiTerceiroAll")]
        [ProducesResponseType(StatusCodes.Status201Created)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ChaveApiTerceiroViewModel chaveApiTerceiroViewModel)
        {
            #region Map
            var chaveApiTerceiroMapped = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiroMapped = _mapper.Map<ChaveApiTerceiro>(chaveApiTerceiroViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.ChavesApiTerceiro.AddAsync(chaveApiTerceiroMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza uma CHAVE DE API TERCEIRO
        /// </summary>
        /// <param name="chaveApiTerceiroViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanChaveApiTerceiroUpdate, CanChaveApiTerceiroAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ChaveApiTerceiroViewModel chaveApiTerceiroViewModel)
        {
            #region Required validations
            if (!chaveApiTerceiroViewModel.Id.HasValue ||
                chaveApiTerceiroViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var chaveApiTerceiroDB = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiroDB = await _context
                                                .ChavesApiTerceiro
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(x => x.Id == chaveApiTerceiroViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (chaveApiTerceiroDB == null)
            {
                AddError("Chave de api de terceiro não encontrada para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var chaveApiTerceiroMap = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiroMap = _mapper.Map<ChaveApiTerceiroViewModel, ChaveApiTerceiro>(chaveApiTerceiroViewModel, chaveApiTerceiroDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update
            try
            {
                _context.ChavesApiTerceiro.Update(chaveApiTerceiroMap);
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
        /// Altera o status de uma CHAVE DE API TERCEIRO
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
        [Authorize(Roles = "Master, CanChaveApiTerceiroUpdate, CanChaveApiTerceiroAll")]
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
            var chaveApiTerceiro = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiro = await _context.ChavesApiTerceiro.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (chaveApiTerceiro == null)
            {
                AddError("Chave de api de terceiro não encontrada para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(chaveApiTerceiro.IsDeleted)
            {
                case true:
                    chaveApiTerceiro.IsDeleted = false;
                    break;
                case false:
                    chaveApiTerceiro.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.ChavesApiTerceiro.Update(chaveApiTerceiro);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status chave de api terceiro alterada com sucesso." } );
        }
    }
}