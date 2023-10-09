using IsSistemCase.Core.Models.BaseEntities;
using IsSistemCase.Core.Repositories;
using IsSistemCase.Core.UnitOfWorks;
using IsSistemCase.Repository.Contexts;

namespace IsSistemCase.Repository.UnitOfWorks
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : Entity, new()
    {
        private readonly IsSistemSqlDbContext _context;
        private readonly IGenericRepository<TEntity> _repository;

        public UnitOfWork(IsSistemSqlDbContext context, IGenericRepository<TEntity> repository)
        {
            _context = context;
            _repository = repository;
        }

        #region IUnitOfWork

        public IGenericRepository<TEntity> GetRepository()
        {
            return _repository;
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region IDisposable

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
