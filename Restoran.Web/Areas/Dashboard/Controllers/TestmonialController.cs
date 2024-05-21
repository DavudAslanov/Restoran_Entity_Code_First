using Bussines.Abstract;
using Bussines.Concrete;
using DataAcess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TestmonialController : Controller
    {
        private readonly ITestmonialService _testmonialService;

        public TestmonialController(ITestmonialService testmonialService)
        {
            _testmonialService = testmonialService;
        }
        public IActionResult Index()
        {
            var data = _testmonialService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TestmonialCreatDto dto)
        {
            var result = _testmonialService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testmonialService.GetById(id).Data;
            return View(data);

        }
        [HttpPost]
        public IActionResult Edit(TestmonialUpdateDto dto)
        {
            var result = _testmonialService.Update(dto);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _testmonialService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
