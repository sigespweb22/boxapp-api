using System;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.Interfaces
{
    public interface IRotinaAppService
    {
        Task<RotinaViewModel> GetByIdAsync(Guid rotinaId);
    }
}