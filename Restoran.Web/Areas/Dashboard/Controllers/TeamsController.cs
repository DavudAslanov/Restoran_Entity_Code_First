using Bussines.Abstract;
using Bussines.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class TeamsController : Controller
    {
        private readonly ITeamsService _teamsService;
        private readonly IPositionService _positionService;
        public TeamsController(ITeamsService teamsService, IPositionService positionService)
        {
            _teamsService = teamsService;
            _positionService = positionService;
        }

        public IActionResult Index()
        {
            var data = _teamsService.GetTeamWithTeamCategories().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PositionId"] = _positionService.GetAll().Data;
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamsCreateDto dto)
        {
            var result = _teamsService.Add(dto);
            ViewData["PositionId"] = _positionService.GetAll().Data;
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
            ViewData["PositionId"] = _positionService.GetAll().Data;

            var data = _teamsService.GetById(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(TeamsUpdateDto dto)
        {
            ViewData["PositionId"] = _positionService.GetAll().Data;
            var result = _teamsService.Update(dto);
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
            var result = _teamsService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
