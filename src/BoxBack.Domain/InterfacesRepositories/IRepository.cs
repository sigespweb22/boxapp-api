using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxBack.Domain.InterfacesRepositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetByIdAsync(Guid id);
        TEntity GetById(Guid id);
        Guid GetIdByIdAsync(Guid id);
        Guid GetIdById(Guid id);
        Guid GetIdFromPropertyAny(string property, string value);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> AsNoTrackingOnlyIsNotDeleted();
        IQueryable<TEntity> AsNoTracking();
        IQueryable<TEntity> GetAll(ISpecification<TEntity> spec);
        IQueryable<TEntity> GetAllSoftDeleted();
        void Update(TEntity obj);
        void UpdateRange(IList<TEntity> obj);
        void Remove(Guid id);

        //Interfaces assíncronas
        Task AddAsync(TEntity obj);
        Task AddRangeAsync(IList<TEntity> obj);
        Task<string> GetIdFromPropertyAnyAsync(string property, string value);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
