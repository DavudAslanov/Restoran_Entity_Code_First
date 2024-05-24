using Bussines.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using Restoran.Web.ViewModels;

namespace Restoran.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ITeamsService _teamsService;

        public AboutController(IAboutService aboutService, ITeamsService teamsService)
        {
            _aboutService = aboutService;
            _teamsService = teamsService;
        }

        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            var team = _teamsService.GetTeamWithTeamCategories().Data;

            AboutViewModel ViewModel = new()
            {
                AboutsDto = aboutData,
                TeamsDto= team,
            };
            return View(ViewModel);
        }
    }
}
