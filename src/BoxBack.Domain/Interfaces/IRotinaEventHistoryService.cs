using System.Threading.Tasks;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Interfaces
{
    public interface IRotinaEventHistoryService
    {
        Task AddAsync(RotinaEventHistory reh);
        void Update(RotinaEventHistory reh);
    }
}