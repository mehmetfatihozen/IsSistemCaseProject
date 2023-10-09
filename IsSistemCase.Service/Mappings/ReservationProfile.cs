using AutoMapper;
using IsSistemCase.Core.DTOs.PublicDTOs.Reservation;
using IsSistemCase.Core.Models.DbEntities;

namespace IsSistemCase.Service.Mappings
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<CreateReservationRequestDto, CreateReservationResponseDto>().ReverseMap();
        }
    }
}
