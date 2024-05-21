using Bussines.Abstract;
using Bussines.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceController : Controller
    {
        private readonly IService _service;
        public ServiceController(IService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var data=_service.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServiceCreateDto dto)
        {
            var result=_service.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ModelState.Clear();
                return View(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data=_service.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(ServiceUpdateDto dto)
        {
            var result=_service.Update(dto);
            if(!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ModelState.Clear();
                return View(dto);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result= _service.Delete(id);
            if(result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
