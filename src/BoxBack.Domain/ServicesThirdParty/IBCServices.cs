using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.ModelsServices;
using System.Collections.Generic;
using System;

namespace BoxBack.Domain.ServicesThirdParty
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
        Task<IList<BCClienteModelService>> ClientePesquisar([Header("Authorization")] string apiKey);

        /// <summary>
        /// Obtém todos os contratos de um cliente
        /// </summary>
        /// <param></param>
        /// <param name="pesquisa"></param>
        /// <param name="apiKey"></param>
        /// <returns>Retorna um json array com todos os contratos de um cliente.</returns>
        /// <response code="200">Retorna sucesso com um array de objetos com os contratos de um cliente.</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Get("/VendaContrato/Pesquisar")]
        [Headers("Content-Type: application/json")]
        Task<BCContratoModelService[]> VendaContratoPesquisar(string pesquisa, [Header("Authorization")] string apiKey);

        /// <summary>
        /// Obtém um contrato de um cliente pelo seu id
        /// </summary>
        /// <param></param>
        /// <param name="id"></param>
        /// <param name="quitadas"></param>
        /// <param name="apiKey"></param>
        /// <returns>Retorna um json com os dados do contrato do cliente</returns>
        /// <response code="200">Retorna sucesso com um objeto com o contrato pesquisado.</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Nenhum contrato encontrado</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Get("/VendaContrato/Obter/{id}?quitadas: quitadas")]
        [Headers("Content-Type: application/json")]
        Task<BCContratoModelService> VendaContratoObter(Int64 id, bool quitadas, [Header("Authorization")] string apiKey);

        /// <summary>
        /// Obtém uma fatura de um contrato de cliente pelo id da fatura
        /// </summary>
        /// <param></param>
        /// <param name="id"></param>
        /// <param name="apiKey"></param>
        /// <returns>Retorna um json com os dados da fatura</returns>
        /// <response code="200">Retorna sucesso com um objeto com a fatura pesquisada.</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Fatura não encontrada</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Get("/Fatura/Obter/{id}")]
        [Headers("Content-Type: application/json")]
        Task<BCFaturaModelService> FaturaObter(Int64 id, [Header("Authorization")] string apiKey);
    }
}