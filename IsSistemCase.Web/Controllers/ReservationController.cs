using IsSistemCase.Core.Services;
using IsSistemCase.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsSistemCase.Web.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IReservationService _reservationService;

		public ReservationController(IReservationService reservationService)
		{
			_reservationService = reservationService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(CreateReservationRequestViewModel request)
		{
			var result = _reservationService.MakeReservation(request);

			if (!result.HasError)
			{
				TempData["SuccessMessage"] = "Rezervasyon başarılı! Detaylar mail olarak iletilmiştir.";

				return RedirectToAction(nameof(ReservationController.Index));
			}

			foreach (string error in result.ErrorMessages)
			{
				ModelState.AddModelError(string.Empty, error);
			}

			return View();
		}
	}
}
