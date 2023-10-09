using IsSistemCase.Core.Models.BaseEntities;
using IsSistemCase.Core.Repositories;

namespace IsSistemCase.Core.UnitOfWorks
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : Entity, new()
    {
        IGenericRepository<TEntity> GetRepository();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
