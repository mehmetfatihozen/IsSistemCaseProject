using IsSistemCase.Core.DTOs.PublicDTOs.Reservation;
using IsSistemCase.Core.DTOs.ResponseDTOs;
using IsSistemCase.Core.Models.DbEntities;

namespace IsSistemCase.Core.Services
{
    public interface IReservationService : IGenericService<Reservation>
    {
        IBaseResponse<CreateReservationResponseDto> MakeReservation(CreateReservationRequestDto request);
    }
}
