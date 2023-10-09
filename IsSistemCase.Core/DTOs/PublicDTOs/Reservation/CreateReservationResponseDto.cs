using IsSistemCase.Core.DTOs.BaseDTOs;

namespace IsSistemCase.Core.DTOs.PublicDTOs.Reservation
{
    public class CreateReservationResponseDto : CreateReservationRequestDto
    {
        public ushort TableNumber { get; set; }
    }
}
