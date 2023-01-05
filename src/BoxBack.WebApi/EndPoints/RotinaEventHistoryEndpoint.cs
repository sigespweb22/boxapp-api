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
    [Route("api/v{version:apiVersion}/rotinas-events-histories")]
    public class RotinaEventHistoryEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RotinaEventHistoryEndpoint(BoxAppDbContext context,
                                          IUnitOfWork unitOfWork,
                                          IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista de todas as ROTINAS EVENTS HISTORIES de uma ROTINA
        /// </summary>
        /// <param name="q"></param>
        /// <param name="rotinaId"></param>
        /// <returns>Um json com as ROTINAS EVENTS HISTORIES</returns>
        /// <response code="200">Lista de ROTINAS EVENTS HISTORIES</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanRotinaEventHistoryList, CanRotinaEventHistoryAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q, string rotinaId)
        {
            if (string.IsNullOrEmpty(rotinaId))
            {
                AddError("Id Rotina requerida.");
                return CustomResponse(400);
            }

            #region Get data
            var rotinasEventsHistories = new List<RotinaEventHistory>();
            try
            {
                rotinasEventsHistories = await _context.RotinasEventsHistories
                                                        .AsNoTracking()
                                                        .Include(x => x.Rotina)
                                                        .Where(x => x.RotinaId == Guid.Parse(rotinaId))
                                                        .OrderByDescending(x => x.DataInicio)
                                                        .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (rotinasEventsHistories == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search 
            if(!string.IsNullOrEmpty(q))
                rotinasEventsHistories = rotinasEventsHistories.Where(x => x.Rotina.Nome.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<RotinaEventHistoryViewModel> rotinaEventHistoryMapped = new List<RotinaEventHistoryViewModel>();
            try
            {
                rotinaEventHistoryMapped = _mapper.Map<IEnumerable<RotinaEventHistoryViewModel>>(rotinasEventsHistories);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = rotinaEventHistoryMapped.ToList(),
                RotinasEventsHistories = rotinaEventHistoryMapped.ToList(),
                Params = q,
                Total = rotinaEventHistoryMapped.Count()
            });
        }

        /// <summary> 
        /// Adiciona uma ROTINA EVENT HISTORY para uma ROTINA
        /// </summary>
        /// <param name="rotinaEventHistoryViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro desconhecido</response>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Master, CanRotinaEventHistoryCreate, CanRotinaEventHistoryAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]RotinaEventHistoryViewModel rotinaEventHistoryViewModel)
        {
            #region Map
            var rotinaEventHistoryMapped = new RotinaEventHistory();
            try
            {
                rotinaEventHistoryMapped = _mapper.Map<RotinaEventHistory>(rotinaEventHistoryViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            rotinaEventHistoryMapped.Rotina = null;
            #endregion

            #region Persistance and commit
            try
            {
                await _context.RotinasEventsHistories.AddAsync(rotinaEventHistoryMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CreatedAtAction(null, new { rotinaId = rotinaEventHistoryViewModel.RotinaId});
        }

        /// <summary>
        /// Retorna uma ROTINA EVENT HISTORY pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto com a ROTINA EVENT HISTORY solicitada</returns>
        /// <response code="200">Lista uma ROTINA EVENT HISTORY</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">ROTINA não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanRotinaEventHistoryRead, CanRotinaEventHistoryAll")]
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
                AddError("Id requerida.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var rotinaEventHistory = new RotinaEventHistory();
            try
            {
                rotinaEventHistory = await _context.RotinasEventsHistories
                                                   .FindAsync(Guid.Parse(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (rotinaEventHistory == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var rotinaEventHistoryMapped = new RotinaEventHistoryViewModel();
            try
            {
                rotinaEventHistoryMapped = _mapper.Map<RotinaEventHistoryViewModel>(rotinaEventHistory);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = rotinaEventHistoryMapped,
                RotinaEventHistory = rotinaEventHistoryMapped,
                Params = id
            });
        }
    }
}