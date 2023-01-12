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

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/servicos")]
    public class ServicoEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicoEndpoint(BoxAppDbContext context,
                               IUnitOfWork unitOfWork,
                               IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os SERVIÇOS
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com os SERVIÇOS</returns>
        /// <response code="200">Lista de SERVIÇOS</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanServicoList, CanServicoAll")]
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
            var servicos = new List<Servico>();
            try
            {
                servicos = await _context.Servicos
                                            .AsNoTracking()
                                            .Include(x => x.FornecedorServico)
                                            .OrderByDescending(x => x.UpdatedAt)
                                            .ToListAsync();
                if (servicos == null)
                {
                    AddError("Não encontrado.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                servicos = servicos.Where(x => x.Nome.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<ServicoViewModel> servicosMapped = new List<ServicoViewModel>();
            try
            {
                servicosMapped = _mapper.Map<IEnumerable<ServicoViewModel>>(servicos);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = servicosMapped.ToList(),
                Servicos = servicosMapped.ToList(),
                Params = q,
                Total = servicosMapped.Count()
            });
        }

        /// <summary>
        /// Lista todos os serviços para uma select2
        /// </summary>
        /// <param name="q"></param>
        /// <param name="isDeleted"></param>
        /// <returns>Um json com os serviços</returns>
        /// <response code="200">Lista de serviços</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanServicoList, CanServicoAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q, bool isDeleted = false)
        {
            #region Get data
            var servicosDB = new List<Servico>();
            try
            {
                servicosDB = await _context
                                        .Servicos
                                        .Where(x => !x.IsDeleted || x.IsDeleted == isDeleted)
                                        .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (servicosDB == null)
            {
                AddError("Não encontrado");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            IEnumerable<ServicoSelect2ViewModel> servicosMap = new List<ServicoSelect2ViewModel>();
            try
            {
                servicosMap = _mapper.Map<IEnumerable<ServicoSelect2ViewModel>>(servicosDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(servicosMap);
        }

        /// <summary>
        /// Cria um SERVIÇOS
        /// </summary>
        /// <param name="servicoViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanServicoCreate, CanServicoAll")]
        [ProducesResponseType(StatusCodes.Status201Created)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ServicoViewModel servicoViewModel)
        {
            #region Map
            var servicoMapped = new Servico();
            try
            {
                servicoMapped = _mapper.Map<Servico>(servicoViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            servicoMapped.FornecedorServico = null;
            #endregion

            #region Persistance and commit
            try
            {
                await _context.Servicos.AddAsync(servicoMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza um SERVIÇOS
        /// </summary>
        /// <param name="servicoViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanServicoUpdate, CanServicoAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ServicoViewModel servicoViewModel)
        {
            #region Required validations
            if (!servicoViewModel.Id.HasValue ||
                servicoViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var servicoDB = new Servico();
            try
            {
                servicoDB = await _context
                                    .Servicos
                                    .Include(x => x.FornecedorServico)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Id == servicoViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (servicoDB == null)
            {
                AddError("Serviço não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            var servicoMap = new Servico();
            try
            {
                servicoMap = _mapper.Map<ServicoViewModel, Servico>(servicoViewModel, servicoDB);
                servicoMap.FornecedorServico = null;
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update
            try
            {
                _context.Servicos.Update(servicoMap);
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
        /// Deleta um SERVIÇOS
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Erro desconhecido</response>
        [Route("delete/{id}")]
        [Authorize(Roles = "Master, CanServicoDelete, CanServicoAll")]
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
            var servico = new Servico();
            try
            {
                servico = await _context.Servicos.FindAsync(id);
                if (servico == null)
                {
                    AddError("Serviço não encontrado para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete
            try
            {
                _context.Servicos.Remove(servico);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de um SERVIÇOS
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
        [Authorize(Roles = "Master, CanServicoUpdate, CanServicoAll")]
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
            var servico = new Servico();
            try
            {
                servico = await _context.Servicos.FindAsync(id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (servico == null)
            {
                AddError("Serviços não encontrado para alterar seu status.");
                return CustomResponse(404);
            }
            #endregion

            #region Map
            switch(servico.IsDeleted)
            {
                case true:
                    servico.IsDeleted = false;
                    break;
                case false:
                    servico.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.Servicos.Update(servico);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status serviço alterado com sucesso." } );
        }
    }
}