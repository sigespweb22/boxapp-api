using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.Models.Services;

namespace BoxBack.Domain.ServicesThirdParty
{
    public interface IGeoNamesEstadosServices
    {
        [Get("/childrenJSON?geonameId=3469034")]
        Task<GeoNamesEstadosModel> GetAllEstados();
    }
}