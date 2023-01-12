using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Infra.Data.Context;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using AutoMapper;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.WebApi.Controllers;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/pipelines")]
    public class PipelineEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PipelineEndpoint(BoxAppDbContext context,
                             IUnitOfWork unitOfWork,
                             IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os pipelines
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com os pipelines</returns>
        /// <response code="200">Lista de pipelines</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanPipelineList, CanPipelineAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q)
        {
            #region Get data
            var pipelines = new List<Pipeline>();
            try
            {
                pipelines = await _context
                                        .Pipelines
                                        .Include(x => x.PipelineAssinantes.Where(x => x.IsDeleted == false))
                                        .ThenInclude(x => x.ApplicationUser)
                                        .Include(x => x.PipelineEtapas)
                                        .ThenInclude(x => x.PipelineTarefas)
                                        .OrderBy(x => x.Posicao)
                                        .ToListAsync();
                if (pipelines.Count() <= 0)
                {
                    AddError("Não encontrado.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                pipelines = pipelines.Where(x => x.Nome.Contains(q.ToUpper())).ToList();
            #endregion

            #region Map
            IEnumerable<PipelineViewModel> pipelineMap = new List<PipelineViewModel>();
            try
            {
                pipelineMap = _mapper.Map<IEnumerable<PipelineViewModel>>(pipelines);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return Ok(new {
                AllData = pipelineMap.ToList(),
                Pipelines = pipelineMap.ToList(),
                Params = q,
                Total = pipelineMap.Count()
            });
        }

        /// <summary>
        /// Cria um pipeline
        /// </summary>
        /// <param name="pipelineViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanPipelineCreate, CanPipelineAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]PipelineViewModel pipelineViewModel)
        {
            #region Map
            var pipelineMap = new Pipeline();
            try
            {
                pipelineMap = _mapper.Map<Pipeline>(pipelineViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Insert data
            try
            {
                await _context.Pipelines.AddAsync(pipelineMap);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza um pipeline
        /// </summary>
        /// <param name="pipelineViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanPipelineUpdate, CanPipelineAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]PipelineViewModel pipelineViewModel)
        {
            #region Required validations
            if (pipelineViewModel.Id == null ||
                pipelineViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var pipelineDB = new Pipeline();
            try
            {
                pipelineDB = await _context
                                    .Pipelines
                                    .Include(x => x.PipelineAssinantes)
                                    .FirstOrDefaultAsync(x => x.Id == pipelineViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (pipelineDB == null)
            {
                AddError("Pipeline não encontrado para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Assinantes remove | Mudar isso pelo amooooor
            _context.PipelineAssinantes.RemoveRange(pipelineDB.PipelineAssinantes);
            #endregion

            #region Map
            var pipelineMap = new Pipeline();
            try
            {
                pipelineMap = _mapper.Map<PipelineViewModel, Pipeline>(pipelineViewModel, pipelineDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update pipeline
            try
            {
                _context.Pipelines.Update(pipelineMap);
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
        /// Deleta um pipeline
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        [Route("delete/{id}")]
        [Authorize(Roles = "Master, CanPipelineDelete, CanPipelineAll")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            #region Validations required
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Get data
            var pipeline = new Pipeline();
            try
            {
                pipeline = await _context
                                    .Pipelines
                                    .FindAsync(id);
                if (pipeline == null)
                {
                    AddError("Pipeline não encontrado para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete
            try
            {
                _context.Pipelines.Remove(pipeline);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }
    }
}