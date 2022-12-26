using System;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Interfaces;

namespace BoxBack.Application.Interfaces
{
    public interface IRotinaAppService
    {
        Task<RotinaViewModel> GetByIdAsync(Guid rotinaId);
    }
}