using IsSistemCase.Core.Models.BaseEntities;

namespace IsSistemCase.Core.Models.DbEntities
{
    public class Reservation : BaseEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid TableId { get; set; }
        public DateTime ReservationDate { get; set; }
        public byte NumberOfGuests { get; set; }

        public virtual Table Table { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
