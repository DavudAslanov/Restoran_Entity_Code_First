using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using Restoran.Web.ViewModels;

namespace Restoran.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IReservationService _reservationService;

        public BookingController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ReservationDto reservationDto)
        {
            var result=_reservationService.BookInAdvance(reservationDto);
            if(result.IsSuccess)
            {
                return View(reservationDto);
            }
            return RedirectToAction("Index");
        }
    }
}
