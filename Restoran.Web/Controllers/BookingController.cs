using Bussines.Abstract;
using Bussines.BaseEntities;
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
        public IActionResult Index(ReservationDto dto)
        {
            var result = _reservationService.BookInAdvance(dto);
            if (result.IsSuccess)
            {
                ModelState.Clear();
                ViewBag.Message = Uimessage.ADD_MESSAGE;
                return View(new ReservationDto());
            }
            return View(dto);
        }

    }
}
