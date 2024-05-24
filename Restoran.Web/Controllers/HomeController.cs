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
        private readonly IService _service;
        private readonly IReservationService _reservationService;

        public HomeController(
            IAboutService aboutService,
            IFoodCategoryService foodCategoryService, 
            IFoodService foodService, ITeamsService teamsService, 
            IPositionService positionService, 
            ITestmonialService testmonialService, 
            IService service, 
            IReservationService reservationService
            )
        {
            _aboutService = aboutService;
            _foodCategoryService = foodCategoryService;
            _foodService = foodService;
            _teamsService = teamsService;
            _positionService = positionService;
            _testmonialService = testmonialService;
            _service = service;
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel dto)
        {
            _reservationService.BookInAdvance(dto.ReservationDto);
            var viewModel = CreateHomeViewModel();
            return Index();
        }

        public IActionResult Index()
        {
            var viewModel = CreateHomeViewModel();
            return View(viewModel);
        }

        private HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel
            {
                AboutsDto = _aboutService.GetAll().Data,
                FoodCategoriesDto = _foodCategoryService.GetAllFoodCategories().Data,
                FoodsDto = _foodService.GetFoodWithFoodCategories().Data.Where(x => x.IsHomePage == true).ToList(),
                TeamsDto = _teamsService.GetTeamWithTeamCategories().Data.Where(x=>x.IsHomePage==true).ToList(),
                PositionsDto = _positionService.GetAll().Data,
                TestmonialsDto = _testmonialService.GetAll().Data,
                ServicesDto = _service.GetAll().Data.Where(x => x.IsHomePage == true).ToList()
            };
        }
    }
}
