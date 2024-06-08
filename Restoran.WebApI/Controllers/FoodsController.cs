using Bussines.Abstract;
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

        public FoodsController(IFoodService foodservice)
        {
            _foodservice = foodservice;
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
        //[HttpPost("PostFoods")]
        //public IActionResult PostFoods(FoodCreateDto dto)
        //{
        //    var result=_foodservice.Add(dto);
        //}
    }
}
