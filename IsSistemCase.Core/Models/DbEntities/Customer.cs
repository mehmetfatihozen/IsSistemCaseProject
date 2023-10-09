using IsSistemCase.Core.Models.BaseEntities;

namespace IsSistemCase.Core.Models.DbEntities
{
    public class Customer : BaseEntity<Guid>
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
