using Bussines.Abstract;
using Bussines.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ContactController : Controller
    {   
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            var data = _contactService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactCreateDto dto)
        {
            var result= _contactService.Add(dto);
            if(!result.IsSuccess)
            {
                ModelState.AddModelError("",result.Message);
                ModelState.Clear();
                return View(dto);
            }
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data= _contactService.GetById(id).Data;
           return View(data);
        }
        [HttpPost]
        public IActionResult Edit(ContactUpdateDto dto)
        {
            var result= _contactService.Update(dto);
            if(!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ModelState.Clear();
                return View(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result= _contactService.Delete(id);
            if(result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
