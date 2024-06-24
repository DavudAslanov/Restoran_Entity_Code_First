using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService _service;

        public ServiceController(IService service)
        {
            _service = service;
        }

        [HttpGet("GetService")]
        public IActionResult GetService()
        {
            var result=_service.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("PostService")]
        public IActionResult PostService(ServiceCreateDto dto)
        {
            var result=_service.Add(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("PutService")]
        public IActionResult PutService(ServiceUpdateDto dto)
        {
            var result=_service.Update(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteService")]
        public IActionResult DeleteService(ServiceDto dto)
        {
            var result = _service.Delete(dto.ID);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
