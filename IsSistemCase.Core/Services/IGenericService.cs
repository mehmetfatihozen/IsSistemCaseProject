using IsSistemCase.Core.Models.BaseEntities;
using System.Linq.Expressions;

namespace IsSistemCase.Core.Services
{
    public interface IGenericService<TEntity> where TEntity : Entity, new()
    {
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
