using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;

namespace BoxBack.Domain.InterfacesRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        ValidationResult CommitVR();
        Task<ValidationResult> CommitAsyncVR();
        Task<int> CommitAsync();
        void CommitWithoutSoftDelete();
    }
}
