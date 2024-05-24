using Bussines.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Controllers
{
    public class TestmonialController : Controller
    {
        private readonly ITestmonialService _testmonialService;

        public TestmonialController(ITestmonialService testmonialService)
        {
            _testmonialService = testmonialService;
        }

        public IActionResult Index()
        {
            var data=_testmonialService.GetAll().Data;
            return View(data);
        }
    }
}
