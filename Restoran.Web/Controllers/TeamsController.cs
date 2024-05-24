using Bussines.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamsService _teamsService;

        public TeamsController(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }
        public IActionResult Index()
        {
            var data = _teamsService.GetTeamWithTeamCategories().Data;
            return View(data);
        }
    }
}
