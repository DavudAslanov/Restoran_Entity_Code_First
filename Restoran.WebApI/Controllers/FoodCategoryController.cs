using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoryController : ControllerBase
    {
        private readonly IFoodCategoryService _foodCategoryService;

        public FoodCategoryController(IFoodCategoryService foodCategoryService)
        {
            _foodCategoryService = foodCategoryService;
        }
        [HttpGet("GetFoodCategory")]
        public IActionResult GetFoodCategory()
        {
            var result=_foodCategoryService.GetAllFoodCategories();
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("PostFoodCategory")]
        public IActionResult PostFoodCategory(FoodCategoryCreateDto dto)
        {
            var result=_foodCategoryService.Add(dto);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("PutFoodCategory")]
        public IActionResult PutFoodCategory(FoodCategoryUpdateDto dto)
        {
            var result = _foodCategoryService.Update(dto);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteFoodCategory")]
        public IActionResult DeleteFoodCategory(FoodCategoryDto dto)
        {
            var result = _foodCategoryService.Delete(dto.Id);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
