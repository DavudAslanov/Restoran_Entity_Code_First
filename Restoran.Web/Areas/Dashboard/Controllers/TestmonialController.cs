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
        private readonly IWebHostEnvironment _env;

        public TestmonialController(ITestmonialService testmonialService, IWebHostEnvironment env)
        {
            _testmonialService = testmonialService;
            _env = env;
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
        public IActionResult Create(TestmonialCreatDto dto, IFormFile PhotoUrl)
        {
            var result = _testmonialService.Add(dto, PhotoUrl, _env.WebRootPath);
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testmonialService.GetById(id).Data;
            return View(data);

        }
        [HttpPost]
        public IActionResult Edit(TestmonialUpdateDto dto, IFormFile PhotoUrl)
        {
            var result = _testmonialService.Update(dto, PhotoUrl, _env.WebRootPath);
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
