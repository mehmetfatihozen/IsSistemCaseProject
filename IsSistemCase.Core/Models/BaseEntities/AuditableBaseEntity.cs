namespace IsSistemCase.Core.Models.BaseEntities
{
    public abstract class AuditableBaseEntity<T> : BaseEntity<T>
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
