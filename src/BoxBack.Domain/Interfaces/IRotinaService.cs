using System;
using System.Threading.Tasks;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Interfaces
{
    public interface IRotinaService
    {
        Task<Rotina> GetByIdAsync(Guid id);
    }
}