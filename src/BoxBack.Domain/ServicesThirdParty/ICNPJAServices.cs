using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.Models.Services;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.Domain.ServicesThirdParty
{
    public interface ICNPJAServices
    {
        /// <summary>
        /// Autentica um usuário e retorna um token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>O token do usuário logado</returns>
        /// <response code="200">Autenticado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Post("/auth")]
        Task<CNPJaTokenModelServices> Auth(CNPJaUserModelServices user);

        /// <summary>
        /// Consulta um CNPJ e retorna os dados da empresa
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Um json com os dados da empresa consultada</returns>
        /// <response code="200">Json com os dados</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">CNPJ não encontrado</response>
        [Get("/office/:{cnpj}")]
        [Headers("Authorization: 3b1191ad-b233-49ad-b4ea-6e2495adc213-aa03381c-f4e5-4840-836b-2e8ba2ca9480")]
        Task<CNPJaEmpresaModelService> ConsultaEstabelecimento(string cnpj);
    }
}