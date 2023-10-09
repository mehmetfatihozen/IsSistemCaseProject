using IsSistemCase.Core.Models.BaseEntities;
using IsSistemCase.Core.Repositories;
using IsSistemCase.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IsSistemCase.Repository.Repositories
{
    public class GenericRepositoy<TEntity> : IGenericRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly IsSistemSqlDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepositoy(IsSistemSqlDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsEnumerable();
        }
    }
}
