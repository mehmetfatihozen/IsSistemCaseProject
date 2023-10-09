using System.ComponentModel.DataAnnotations;

namespace IsSistemCase.Core.DTOs.PublicDTOs.Reservation
{
    public class CreateReservationRequestDto
    {
        [Display(Name = "Name :")]
        public string CustomerName { get; set; }
        [Display(Name = "Phone :")]
        public string CustomerPhone { get; set; }
        [Display(Name = "Email :")]
        public string CustomerEmail { get; set; }
        [Display(Name = "Reservation Date :")]
        public DateTime ReservationDate { get; set; }
        [Display(Name = "Number of Guests :")]
        public byte NumberOfGuests { get; set; }
    }
}
