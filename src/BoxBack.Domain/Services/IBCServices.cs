using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.ModelsServices;
using System.Collections.Generic;

namespace BoxBack.Domain.Services
{
    public interface IBCServices
    {
        /// <summary>
        /// Cadastra um cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns>Um json com os dados do cliente consultado</returns>
        /// <response code="201">Cliente cadastrado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Post("/Cliente/Criar")]
        [Headers("Authorization: ApiKey Z0EjZPzTOb-NVurlZvdf-jqb2g6FUvIlKBmvUVCh7sE03jMPBaCQ9bIps9El6__SynsbTrCaUm1yI2geYNx3JSPNELf-pDy5HaUUcTkvYNw8nwlkDozDnA==")]
        Task<BCClienteModelService> ClienteCriar(BCClienteModelService clienteModel);

        /// <summary>
        /// Obtém um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="apiKey"></param>
        /// <returns>Retorna um objeto com os dados do Cliente.</returns>
        /// <response code="200">Retorna sucesso com um objeto com os dados do Cliente.</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Get("/Cliente/Obter/{id}")]
        [Headers("Content-Type: application/json")]
        Task<BCClienteModelService> ClienteObter(string id, [Header("Authorization")] string apiKey);

        /// <summary>
        /// Obtém todos os clientes
        /// </summary>
        /// <param></param>
        /// <param name="apiKey"></param>
        /// <returns>Retorna um json array com todos os clientes.</returns>
        /// <response code="200">Retorna sucesso com um objeto com os clientes.</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Get("/Cliente/Pesquisar?pesquisa=")]
        [Headers("Content-Type: application/json")]
        Task<IEnumerable<BCClienteModelService>> ClientePesquisar([Header("Authorization")] string apiKey);
    }
}