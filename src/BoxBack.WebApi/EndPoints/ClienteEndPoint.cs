using System.Net;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.AccessControl;
using BoxBack.WebApi.EndPoints;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.InterfacesNoSQL;
using BoxBack.Domain.ModelsNoSQL;
using BoxBack.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoxBack.WebApi.EndPoints
{
    [Produces("application/json")]
    [Route("api/v1/clientes")]
    public class ClienteEndPoint : ApiController
    {
        private readonly IClienteRepositoryNoSQL _clienteRepositoryNoSQL;
        private readonly IMapper _mapper;

        public ClienteEndPoint(IClienteRepositoryNoSQL clienteRepositoryNoSQL,
                                IMapper mapper)
        {
            _clienteRepositoryNoSQL = clienteRepositoryNoSQL;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <param name=""></param>
        /// <returns>Um json de clientes</returns>
        /// <response code="200">Returns a list itens</response>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the item is not exist</response>
        [HttpGet]
        [Authorize(Roles = "MASTER, CLIENTE_ALL")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync()
        {
            var clientes = await _clienteRepositoryNoSQL.GetAll();
            var result = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);

            if (result == null || result.Count() <= 0)
                return StatusCode(404, "Nenhum cliente encontrado.");

            return Ok (new
            {
                Success = true,
                Message = "OK",
                Data = result
            });
        }

        /// <summary>
        /// Efetua o cadastro de um novo cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "MASTER, CLIENTE_ADD")]
        public async Task Post([FromBody] Cliente cliente)
        {
            await _clienteRepositoryNoSQL.AddAsync(cliente);
        }

        /// <summary>
        /// Deleta um cliente específico.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Verdadeiro caso tenha sido deletado ou falso caso não</returns>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the item is not exist</response>
        [HttpDelete]
        [Authorize(Roles = "MASTER, CLIENTE_REMOVE")]
        public async Task<bool> DeleteAsync(string id)
        {
            return await _clienteRepositoryNoSQL.RemoveAsync(id);
        }
    }
}