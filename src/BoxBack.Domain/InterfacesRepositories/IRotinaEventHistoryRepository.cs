using System;
using System.Threading.Tasks;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.Domain.Models;

namespace Sigesp.Domain.InterfacesRepositories
{
    public interface IRotinaEventHistoryRepository : IRepository<RotinaEventHistory>
    {
        Task<RotinaEventHistory> GetByIdWithIncludeAsync(Guid id);
    }
}