using Bussines.Abstract;
using Microsoft.AspNetCore.Mvc;
using Restoran.Web.ViewModels;

namespace Restoran.Web.Controllers
{
    
    public class MenuController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly IFoodCategoryService _foodCategoryService;

        public MenuController(IFoodService foodService, IFoodCategoryService foodCategoryService)
        {
            _foodService = foodService;
            _foodCategoryService = foodCategoryService;
        }

        public IActionResult Index()
        {
            var foodData=_foodService.GetFoodWithFoodCategories().Data;
            var foodCategoryData=_foodCategoryService.GetAllFoodCategories().Data;
            MenuViewModel menuViewModel = new()
            {
                FoodsDto = foodData,
                FoodCategoriesDto = foodCategoryData,
            };
            return View(menuViewModel);
        }
    }
}
