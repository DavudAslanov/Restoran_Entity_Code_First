using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact()
        {
            var result = _contactService.GetAll();
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("PostContact")]
        public IActionResult PostContact(ContactCreateDto dto)
        {
            var result = _contactService.Add(dto);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("PutContact")]
        public IActionResult PutContact(ContactUpdateDto dto)
        {
            var result= _contactService.Update(dto);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteContact")]
        public IActionResult DeleteContact(ContactDto dto)
        {
            var result = _contactService.Delete(dto.ID);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
