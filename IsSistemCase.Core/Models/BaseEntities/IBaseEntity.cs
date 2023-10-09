namespace IsSistemCase.Core.Models.BaseEntities
{
    public interface IBaseEntity<T> : IEntity
    {
        public T Id { get; set; }
    }
}
