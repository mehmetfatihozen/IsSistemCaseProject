namespace IsSistemCase.Core.Models.BaseEntities
{
    public interface IAuditableBaseEntity<T> : IBaseEntity<T>
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
