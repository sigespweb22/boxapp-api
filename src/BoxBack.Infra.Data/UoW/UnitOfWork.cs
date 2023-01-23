using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.Infra.Data.Context;

namespace BoxBack.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoxAppDbContext _context;

        public UnitOfWork(BoxAppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public ValidationResult CommitVR()
        {
            var commit = _context.SaveChanges();

            if (commit == 1) {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Error commit.");
            }
        }
        public async Task<ValidationResult> CommitAsyncVR()
        {
            int commitAsync;

            try
            {
                commitAsync = await _context.SaveChangesAsync();     
            }
            catch (System.Exception ex)
            {
                
                return new ValidationResult(ex.ToString());
            }
            
            if (commitAsync == 1)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Error commitAsync.");
            }
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void CommitWithoutSoftDelete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
