using Bussines.Abstract;
using Bussines.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public IActionResult Index()
        {
            var data = _positionService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PositionCreateDto dto)
        {
            var result = _positionService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _positionService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(PositionUpdateDto dto)
        {
            var result = _positionService.Update(dto);
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
            var result = _positionService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
