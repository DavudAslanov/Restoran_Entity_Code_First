using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public IActionResult Index()
        {
            var data = _aboutService.GetAll().Data;

            ViewBag.ShowButton = data.Count()==0;

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AboutCreateDto dto)
        {
            var result = _aboutService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Description", result.Message);
                //ModelState.Clear();
                return View(dto);
            }
            return RedirectToAction("Index");
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _aboutService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(AboutUpdateDto dto)
        {
            var result = _aboutService.Update(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Description",result.Message);
                return View(dto);
                
            }
            return RedirectToAction("Index");
        }
    }
}
