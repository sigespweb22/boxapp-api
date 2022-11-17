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
using BoxBack.Domain.Interfaces;
using BoxBack.WebApi.Controllers;
using BoxBack.Application.ViewModels.Dashboard.Comercial;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/dashboard-comercial")]
    public class DashboardComercialEndpoint : ApiController
    {
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardComercialEndpoint(BoxAppDbContext context,
                                       IUnitOfWork unitOfWork,
                                       IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista o total de clientes ativos com contratos e percentual de novos clientes nos últimos 6 meses
        /// </summary>
        /// <param></param>
        /// <returns>Um json com o total de clientes ativos e percentual de novos clientes nos últimos 6 meses</returns>
        /// <response code="200">Lista o total de clientes ativos com contratos e percentual de novos clientes nos últimos 6 meses</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="404">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanDashboardComercialClienteContratoList, CanDashboardComercialAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("clientes-contratos")]
        [HttpGet]
        public async Task<IActionResult> ClientesContratosAsync()
        {
            #region Get data
            var clientes = new List<Cliente>();
            var totalClienteSemContrato = new List<Cliente>();
            try
            {
                clientes = await _context.Clientes
                                            .AsNoTracking()
                                            .Include(x => x.ClienteContratos)
                                            .OrderByDescending(x => x.UpdatedAt)
                                            .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clientes == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var clienteContratoChartViewModel = new ClienteContratoChartViewModel()
            {
                TotalClientesSemContrato = clientes.Count(x => x.ClienteContratos.Count() <= 0),
                TotalClientesComContrato = clientes.Count(x => x.ClienteContratos.Count() > 0),
                TotalClientesUltimosMeses = 0
            };
            #endregion
            
            return Ok(clienteContratoChartViewModel);
        }
    }
}