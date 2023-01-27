using System;
using System.Linq;
using BoxBack.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using BoxBack.Domain.InterfacesRepositories;
using System.Linq.Expressions;

namespace BoxBack.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BoxAppDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(BoxAppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }
        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual Guid GetIdFromPropertyAny(string property, string value)
        {
            var getId = DbSet
                        .AsNoTracking()
                        .Where(e => EF.Property<string>(e, property).Contains(value))
                        .Select(e => EF.Property<Guid>(e, "Id"))
                        .FirstOrDefault();

            return getId;
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
        public virtual IQueryable<TEntity> AsNoTrackingOnlyIsNotDeleted()
        {
            return DbSet
                    .AsNoTracking()
                    .Where(e => EF.Property<bool>(e, "IsDeleted") == false);
        }
        public virtual IQueryable<TEntity> AsNoTracking()
        {
            return DbSet
                    .AsNoTracking();
                    
        }
        public virtual IQueryable<TEntity> GetAll(ISpecification<TEntity> spec)
        {
            return ApplySpecification(spec);
        }
        public virtual IQueryable<TEntity> GetAllSoftDeleted()
        {
            return DbSet.IgnoreQueryFilters()
                .Where(e => EF.Property<bool>(e, "IsDeleted") == true);
        }
        public virtual void Update(TEntity obj)
        {
            // var entity = DbSet.Find(obj);
            // Db.Entry(entity).CurrentValues.SetValues(obj);
            DbSet.Update(obj);
        }
        public virtual void Remove(Guid id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(DbSet.AsQueryable(), spec);
        }

        //Métodos assíncronos
        public async Task AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
        }
        public async Task AddRangeAsync(IList<TEntity> obj)
        {
            await DbSet.AddRangeAsync(obj);
        }
        public virtual void UpdateRange(IList<TEntity> obj)
        {
            DbSet.UpdateRange(obj);
        }
        public async Task<string> GetIdFromPropertyAnyAsync(string property, string value)
        {
            var getId = await DbSet
                        .AsNoTracking()
                        .Where(e => EF.Property<string>(e, property).Contains(value))
                        .Select(e => EF.Property<Guid>(e, "Id").ToString())
                        .FirstOrDefaultAsync();

            return getId;
        }
        public Guid GetIdByIdAsync(Guid id)
        {
            var getId = DbSet
                            .AsNoTracking()
                            .Where(e => EF.Property<Guid>(e, "Id") == id)
                            .Select(e => EF.Property<Guid>(e, "Id"))
                            .FirstOrDefault();

            return getId;
        }
        public Guid GetIdById(Guid id)
        {
            var getId = DbSet
                            .AsNoTracking()
                            .Where(e => EF.Property<Guid>(e, "Id") == id)
                            .Select(e => EF.Property<Guid>(e, "Id"))
                            .FirstOrDefault();

            return getId;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await DbSet
                            .Where(e => EF.Property<bool>(e, "IsDeleted") == false)
                            .ToListAsync();
                                    
            return entities;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}