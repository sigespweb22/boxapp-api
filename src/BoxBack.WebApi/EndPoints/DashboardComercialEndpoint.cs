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
        [Authorize(Roles = "Master, CanDashboardComercialClienteContratoList, CanDashboardComercialAll, CanDashboardAll")]
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
                TotalClientesComContrato = clientes.Count(x => x.ClienteContratos.Count() >= 1),
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
        [Authorize(Roles = "Master, CanDashboardComercialClienteContratoList, CanDashboardComercialAll, CanDashboardAll")]
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
                clientesContratos = await _context.ClientesContratos
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

        /// <summary>
        /// Lista de valores de ticket médio com base nos valores dos contratos de clientes. Ticket médio mensal e anual
        /// </summary>
        /// <param></param>
        /// <returns>Um json com valores de ticket médio</returns>
        /// <response code="200">Lista de valores de ticket médio com base nos valores dos contratos de clientes</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanDashboardComercialClienteContratoList, CanDashboardComercialAll, CanDashboardAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("clientes-contratos/ticket-medio")]
        [HttpGet]
        public async Task<IActionResult> ClientesContratosTicketMedioAsync()
        {
            #region Get data
            var clientesContratos = new List<ClienteContrato>();
            try
            {
                clientesContratos = await _context.ClientesContratos
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

            #region Get calculations
            var clientesContratosTicketMedioChartViewModel = new ClientesContratosTicketMedioChartViewModel();
            try
            {
                clientesContratosTicketMedioChartViewModel.ValorTicketMedioMensal = CalcularTicketMedioMensal(clientesContratos.Where(x => x.Periodicidade.Equals(PeriodicidadeEnum.MENSAL)));
                clientesContratosTicketMedioChartViewModel.ValorTicketMedioAnual = CalcularTicketMedioAnual(clientesContratos.Where(x => x.Periodicidade.Equals(PeriodicidadeEnum.ANUAL)));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return Ok(clientesContratosTicketMedioChartViewModel);
        }

        private decimal CalcularTicketMedioMensal(IEnumerable<ClienteContrato> contratosMensais)
        {
            var totalContratos = contratosMensais.Count();
            var valorTotalContratos = contratosMensais.Sum(x => x.ValorContrato);
            
            if (totalContratos <= 0 && valorTotalContratos <= 0) return 0;
            return valorTotalContratos / totalContratos;
        }

        private decimal CalcularTicketMedioAnual(IEnumerable<ClienteContrato> contratosAnuais)
        {
            var totalContratos = contratosAnuais.Count();
            var valorTotalContratos = contratosAnuais.Sum(x => x.ValorContrato);
            
            if (totalContratos <= 0 && valorTotalContratos <= 0) return 0;
            return valorTotalContratos / totalContratos / 12;
        }
    }
}