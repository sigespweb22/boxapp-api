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
        Task<ClienteContratoFatura[]> GetAllQuitadasByCompetenciaAsync(DateTime dataInicio, DateTime dataFim);
        Task<ClienteContratoFatura[]> GetAllQuitadasByVendedorIdAsync(DateTime dataInicio, DateTime dataFim, Guid vendedorId);
    }
}