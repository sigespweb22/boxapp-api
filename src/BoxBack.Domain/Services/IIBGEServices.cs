using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Services
{
    public interface IIBGEServices
    {
        [Get("/")]
        Task<IEnumerable<IBGEEstado>> GetAllEstados();
    }
}