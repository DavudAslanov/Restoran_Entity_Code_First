using Bussines.Abstract;
using Bussines.BaseEntities;
using Core.Extenstion;
using Core.Results.Concrete;
using DataAcess.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodservice;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFoodDal _foodDal;

        public FoodsController(IFoodService foodservice, IWebHostEnvironment webHostEnvironment, IFoodDal foodDal)
        {
            _foodservice = foodservice;
            _webHostEnvironment = webHostEnvironment;
            _foodDal = foodDal;
        }

        [HttpGet("GetFoods")]
        public IActionResult GetFoods()
        {
            var result=_foodservice.GetFoodWithFoodCategories();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("PostFoods")]
        public IActionResult PostFoods(FoodCreateDto dto, IFormFile photoUrl, string webRootPath)   
        {
            var result = _foodservice.Add(dto,photoUrl,webRootPath);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
