using Bussines.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService _service;

        public ServiceController(IService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var data=_service.GetAll().Data;
            return View(data);
        }
    }
}
