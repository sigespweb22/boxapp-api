using System;
using System.Threading.Tasks;

namespace BoxBack.Domain.Interfaces
{
    public interface IClienteService
    {
        Task SincronizarFromTPAsync(string token);
    }
}