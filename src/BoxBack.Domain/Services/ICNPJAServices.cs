using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.Models.Services;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.Domain.Services
{
    public interface ICNPJAServices
    {
        [Post("/auth")]
        Task<CNPJaTokenModelServices> Auth(CNPJaUserModelServices user);

        [Get("/office/:{cnpj}")]
        [Headers("Authorization: 3b1191ad-b233-49ad-b4ea-6e2495adc213-aa03381c-f4e5-4840-836b-2e8ba2ca9480")]
        Task<CNPJaEmpresaModelService> ConsultaEstabelecimento(string cnpj);
    }
}