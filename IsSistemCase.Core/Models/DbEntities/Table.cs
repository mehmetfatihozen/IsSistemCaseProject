using IsSistemCase.Core.Models.BaseEntities;

namespace IsSistemCase.Core.Models.DbEntities
{
    public class Table : BaseEntity<Guid>
    {
        public ushort Number { get; set; }
        public byte Capacity { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
