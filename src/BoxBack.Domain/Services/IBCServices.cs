using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.Models.Services;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.Domain.Services
{
    public interface IBCServices
    {
        /// <summary>
        /// Consulta um CNPJ e retorna os dados do cliente
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Um json com os dados do cliente consultado</returns>
        /// <response code="200">Json com os dados</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">CNPJ não encontrado</response>
        [Get("/Cliente/Pesquisar?pesquisa={cnpj}")]
        [Headers("ApiKey Z0EjZPzTOb-8NpoAk4GtAa8xOF7FW8cQDS4OPyGpk90XLOgEysE3zLAD7ClZLMNaynsbTrCaUm1lQiABFUNKY5Gg92GcpUhpHaUUcTkvYNyhbXzYG7zLggKd7MwMR1qwsW16kQFhc94.")]
        Task<BCClienteModelService> ClienteConsulta(string cnpj);
    }
}