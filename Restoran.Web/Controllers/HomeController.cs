using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;
using Restoran.Web.ViewModels;

namespace Restoran.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IFoodCategoryService _foodCategoryService;
        private readonly IFoodService _foodService;
        private readonly ITeamsService _teamsService;
        private readonly IPositionService _positionService;
        private readonly ITestmonialService _testmonialService;
        public HomeController(IAboutService aboutService, IFoodCategoryService foodCategoryService, IFoodService foodService, ITeamsService teamsService, IPositionService positionService, ITestmonialService testmonialService)
        {
            _aboutService = aboutService;
            _foodCategoryService = foodCategoryService;
            _foodService = foodService;
            _teamsService = teamsService;
            _positionService = positionService;
            _testmonialService = testmonialService;
        }

        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            var foodCategory=_foodCategoryService.GetAllFoodCategories().Data;
            var food=_foodService.GetFoodWithFoodCategories().Data;
            var team=_teamsService.GetTeamWithTeamCategories().Data;
            var position = _positionService.GetAll().Data;
            var testmonial = _testmonialService.GetAll().Data;
            HomeViewModel ViewModel = new()
            {
                FoodCategoriesDto = foodCategory,
                AboutsDto = aboutData,
                FoodsDto = food,
                TeamsDto= team,
                PositionsDto = position,
                TestmonialsDto = testmonial,
            };
            return View(ViewModel);
        }
    }
}
