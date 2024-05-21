using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IActionResult Index()
        {
            var data = _reservationService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data= _reservationService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(ReservationUpdateDto dto)
        {
            var result=_reservationService.Update(dto);
            if (!string.IsNullOrEmpty(result.Message))
            {
                var individualErrors = result.Message.Split(", ");
                if (!result.IsSuccess)
                {
                    foreach (var errorMessage in individualErrors)
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("", errorMessage);
                    }
                    return View(dto);
                }
            }
            return RedirectToAction("Index");
        }
       
    }
}
