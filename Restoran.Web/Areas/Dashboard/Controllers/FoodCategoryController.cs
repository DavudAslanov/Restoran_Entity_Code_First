using Bussines.Abstract;
using Bussines.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FoodCategoryController : Controller
    {
        private readonly IFoodCategoryService _foodCategoryService;
        private readonly IWebHostEnvironment _env;

        public FoodCategoryController(IFoodCategoryService foodCategoryService, IWebHostEnvironment env)
        {
            _foodCategoryService = foodCategoryService;
            _env = env;
        }
        public IActionResult Index()
        {
            var data = _foodCategoryService.GetAllFoodCategories().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FoodCategoryCreateDto dto, IFormFile IconName)
        {
            var result = _foodCategoryService.Add(dto, IconName, _env.WebRootPath);

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
            var data = _foodCategoryService.GetById(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(FoodCategoryUpdateDto dto, IFormFile IconName)
        {
            var result = _foodCategoryService.Update(dto, IconName, _env.WebRootPath);
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
            var result = _foodCategoryService.Delete(id);
            if (!result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
