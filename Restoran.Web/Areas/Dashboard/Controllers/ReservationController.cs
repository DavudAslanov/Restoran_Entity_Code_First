using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
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
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _reservationService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }



    }
}
