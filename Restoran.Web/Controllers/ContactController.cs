using Bussines.Abstract;
using Bussines.BaseEntities;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactCreateDto dto)
        {
            var result = _contactService.Add(dto);
            if (result.IsSuccess)
            {
                ModelState.Clear();
                ViewBag.Message =Uimessage.ADD_MESSAGE;
                return View(new ContactCreateDto());
            }
            return View(dto);
        }
    }
}
