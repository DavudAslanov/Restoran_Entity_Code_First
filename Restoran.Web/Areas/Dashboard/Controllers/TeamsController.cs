using Bussines.Abstract;
using Bussines.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
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
            var data= _teamsService.GetTeamWithTeamCategories().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var data=_positionService.GetAll().Data;
            ViewData["PositionId"] =data;
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamsCreateDto dto)
        {
            var result= _teamsService.Add(dto);
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
            ViewData["PositionId"] = _positionService.GetAll().Data;
            
            var data=  _teamsService.GetById(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(TeamsUpdateDto dto)
        {
            var result =  _teamsService.Update(dto);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result =  _teamsService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
