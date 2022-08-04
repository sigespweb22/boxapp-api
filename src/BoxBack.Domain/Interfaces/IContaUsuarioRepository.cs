using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.Models;

namespace BoxBack.Domain.Interfaces
{
    public interface IContaUsuarioRepository : IRepository<ContaUsuario>
    {
        new Task<ContaUsuario> GetByIdAsync(Guid id);
        ContaUsuario GetByUserId(string usuarioId);
        ContaUsuario GetByIdWithInclude(Guid id);
        new Task<IEnumerable<ContaUsuario>> GetAll();
        ContaUsuario GetByUserIdNotIncludes(string usuarioId);
    }
}