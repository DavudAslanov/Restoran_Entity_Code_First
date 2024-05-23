using Bussines.Abstract;
using Bussines.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly IFoodCategoryService _foodCategoryService;
        private readonly IWebHostEnvironment _env;
        public FoodController(IFoodService foodService, IFoodCategoryService foodCategoryService, IWebHostEnvironment env)
        {
            _foodService = foodService;
            _foodCategoryService = foodCategoryService;
            _env = env;
        }
        public IActionResult Index()
        {
            var data = _foodService.GetFoodWithFoodCategories().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["FoodCategorie"] = _foodCategoryService.GetAllFoodCategories().Data;

            return View();
        }
        [HttpPost]
        public IActionResult Create(FoodCreateDto dto,IFormFile photoUrl)
        {
            var result = _foodService.Add(dto, photoUrl, _env.WebRootPath);
            ViewData["FoodCategorie"] = _foodCategoryService.GetAllFoodCategories().Data;
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
            ViewData["FoodCategorie"] = _foodCategoryService.GetAllFoodCategories().Data;

            var data = _foodService.GetById(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(FoodUpdateDto dto, IFormFile photoUrl)  
        {
            var result = _foodService.Update(dto, photoUrl, _env.WebRootPath);
            ViewData["FoodCategorie"] = _foodCategoryService.GetAllFoodCategories().Data;
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
            var result = _foodService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }

    }
}
