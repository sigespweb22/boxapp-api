using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
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
        /// </summary>s
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
                                        .Include(x => x.Assinantes)
                                        .ThenInclude(x => x.ApplicationUser)
                                        .Include(x => x.Etapas)
                                        .ThenInclude(x => x.Tarefas)
                                        .OrderBy(x => x.Nome)
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