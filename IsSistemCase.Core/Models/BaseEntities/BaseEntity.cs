namespace IsSistemCase.Core.Models.BaseEntities
{
    public abstract class BaseEntity<T> : Entity
    {
        public T Id { get; set; }
    }
}
