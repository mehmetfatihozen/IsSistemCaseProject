using IsSistemCase.Core.Models.BaseEntities;
using IsSistemCase.Core.Services;
using IsSistemCase.Core.UnitOfWorks;
using System.Linq.Expressions;

namespace IsSistemCase.Service.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : Entity , new()
    {
        protected readonly IUnitOfWork<TEntity> _unitOfWork;

        public GenericService(IUnitOfWork<TEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _unitOfWork.GetRepository().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual TEntity Add(TEntity entity)
        {
            _unitOfWork.GetRepository().Add(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _unitOfWork.GetRepository().Update(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _unitOfWork.GetRepository().Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.GetRepository().GetAsync(predicate);
        }

        public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.GetRepository().Get(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.GetRepository().GetAll();
        }

        public virtual IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.GetRepository().Where(predicate);
        }
    }
}
