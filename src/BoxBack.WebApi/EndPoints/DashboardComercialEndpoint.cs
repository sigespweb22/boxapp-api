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
using BoxBack.Domain.Enums;

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
        /// Lista o total de clientes ativos com contratos e a representação percentual deste número em relação ao total de clientes ativos
        /// </summary>
        /// <param></param>
        /// <returns>Um json com o total de clientes ativos e a representação percentual deste número em relação ao total de clientes ativos</returns>
        /// <response code="200">Lista o total de clientes ativos com contratos e a representação percentual deste número em relação ao total de clientes ativos</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanDashboardComercialClienteContratoList, CanDashboardComercialAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("clientes-contratos/numeros")]
        [HttpGet]
        public async Task<IActionResult> ClientesContratosNumerosAsync()
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
            var clientesContratosNumerosChartViewModel = new ClientesContratosNumerosChartViewModel()
            {
                TotalClientesSemContrato = clientes.Count(x => x.ClienteContratos.Count() <= 0),
                TotalClientesComContrato = clientes.Count(x => x.ClienteContratos.Count() > 0),
                TotalClientesUltimosMeses = 0
            };
            #endregion
            
            return Ok(clientesContratosNumerosChartViewModel);
        }

        /// <summary>
        /// Lista de valores de contratos. Somatória de todos os contratos, contratos mensais e anuais
        /// </summary>
        /// <param></param>
        /// <returns>Um json com valores de contratos</returns>
        /// <response code="200">Lista o total de clientes ativos com contratos e a representação percentual deste número em relação ao total de clientes ativos</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanDashboardComercialClienteContratoList, CanDashboardComercialAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("clientes-contratos/valores")]
        [HttpGet]
        public async Task<IActionResult> ClientesContratosValoresAsync()
        {
            #region Get data
            var clientesContratos = new List<ClienteContrato>();
            try
            {
                clientesContratos = await _context.ClienteContratos
                                                    .AsNoTracking()
                                                    .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (clientesContratos == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var clientesContratosValoresChartViewModel = new ClientesContratosValoresChartViewModel()
            {
                TotalEmReaisTodosOsContratos = clientesContratos.Sum(x => x.ValorContrato),
                TotalEmReaisContratosMensais = clientesContratos.Where(x => x.Periodicidade.Equals(PeriodicidadeEnum.MENSAL)).Sum(x => x.ValorContrato),
                TotalEmReaisContratosAnuais = clientesContratos.Where(x => x.Periodicidade.Equals(PeriodicidadeEnum.ANUAL)).Sum(x => x.ValorContrato)
            };
            #endregion
            
            return Ok(clientesContratosValoresChartViewModel);
        }
    }
}