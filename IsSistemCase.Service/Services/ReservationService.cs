using AutoMapper;
using IsSistemCase.Core.DTOs.PublicDTOs.Reservation;
using IsSistemCase.Core.DTOs.ResponseDTOs;
using IsSistemCase.Core.Models.DbEntities;
using IsSistemCase.Core.Services;
using IsSistemCase.Core.UnitOfWorks;

namespace IsSistemCase.Service.Services
{
	public class ReservationService : GenericService<Reservation>, IReservationService
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork<Table> _tableUnitOfWork;
		private readonly IUnitOfWork<Customer> _customerUnitOfWork;
		private readonly IEmailService _emailService;

		public ReservationService(IUnitOfWork<Reservation> unitOfWork,
								  IMapper mapper,
								  IUnitOfWork<Table> tableUnitOfWork,
								  IUnitOfWork<Customer> customerUnitOfWork,
								  IEmailService emailService) : base(unitOfWork)
		{
			_mapper = mapper;
			_tableUnitOfWork = tableUnitOfWork;
			_customerUnitOfWork = customerUnitOfWork;
			_emailService = emailService;
		}

		public IBaseResponse<CreateReservationResponseDto> MakeReservation(CreateReservationRequestDto request)
		{
			#region CheckReservationInfo
			var errorMessages = CheckReservationInfo(request);
			if (errorMessages.Count > 0)
			{
				return BaseResponse<CreateReservationResponseDto>.Fail(errorMessages);
			}
			#endregion

			#region GetAvailableTables
			var tables = GetAvailableTables(request.ReservationDate, request.NumberOfGuests);
			if (tables == null || tables.Count == 0)
			{
				return BaseResponse<CreateReservationResponseDto>.Fail("Üzgünüz, uygun masa bulunamadı.");
			}
			#endregion

			#region AddCustomer
			var customer = _customerUnitOfWork.GetRepository().Add(new Customer
			{
				Name = request.CustomerName,
				Phone = request.CustomerPhone,
				Email = request.CustomerEmail,
			});
			_customerUnitOfWork.SaveChanges();
			#endregion

			#region AddReservation
			_unitOfWork.GetRepository().Add(new Reservation
			{
				CustomerId = customer.Id,
				TableId = tables[0].Id,
				ReservationDate = request.ReservationDate,
				NumberOfGuests = request.NumberOfGuests,
			});
			_unitOfWork.SaveChanges();
			#endregion

			#region Send Mail
			var message = $"Sayın {request.CustomerName}, rezervasyonunuz başarıyla alındı. Masa No: {tables[0].Number}, Tarih: {request.ReservationDate}, Kişi Sayısı: {request.NumberOfGuests}";
			_emailService.SendEmail(customer.Email, "Rezervasyon Onayı", message);
			#endregion

			var responseDto = _mapper.Map<CreateReservationResponseDto>(request);
			responseDto.TableNumber = tables[0].Number;

			return BaseResponse<CreateReservationResponseDto>.Success(responseDto);
		}

		private List<Table> GetAvailableTables(DateTime date, int guests)
		{
			DateTime searchStartDate = date.AddHours(-2);
			DateTime searchEndDate = date.AddHours(2);

			var unavailableTables = _unitOfWork.GetRepository().Where(x => searchStartDate < x.ReservationDate && x.ReservationDate < searchEndDate).Select(x => x.TableId).ToList();

			var availableTables = _tableUnitOfWork.GetRepository()
											.Where(x => x.Capacity >= guests)
											.SkipWhile(x => x.Id == unavailableTables.Find(y => y == x.Id))
											.OrderBy(x => x.Capacity)
											.ToList();

			return availableTables;
		}

		private List<string> CheckReservationInfo(CreateReservationRequestDto request)
		{
			var errorList = new List<string>();

			if (request.ReservationDate < DateTime.Now.AddHours(3))
			{
				errorList.Add("Üzgünüz, şu andan itibaren en erken 3 saat sonraya rezervasyon yapabilirsiniz.");
			}

			if (request.ReservationDate.Hour < 10 || request.ReservationDate.Hour > 20)
			{
				errorList.Add("Üzgünüz, sadece saat 10:00 ile 20:00 arasında rezervasyon yapabilirsiniz.");
			}

			if (request.NumberOfGuests > 8)
			{
				errorList.Add("8 kişiyi aşan rezervasyonlar için lütfen restoran müdürümüzle irtibata geçiniz.");
			}

			return errorList;
		}
	}
}
