using System;
using System.Threading.Tasks;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.Domain.Models;
using BoxBack.Domain.ModelsServices;

namespace Sigesp.Domain.InterfacesRepositories
{
    public interface IClienteContratoFaturaRepository : IRepository<ClienteContratoFatura>
    {
        bool AlreadyByParams(AlreadyModelParam args);
        Task<ClienteContratoFatura[]> GetAllByCompetenciaAsAndQuitadasync(DateTime dataInicio, DateTime dataFim);
    }
}