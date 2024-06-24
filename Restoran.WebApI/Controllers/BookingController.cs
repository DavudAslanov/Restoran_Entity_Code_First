using Bussines.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public BookingController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("GetReservation")]
        public IActionResult GetReservation()
        {
            var result=_reservationService.GetAll();
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("PostReservation")]
        public IActionResult PostReservation(ReservationDto dto)
        {
            var result = _reservationService.BookInAdvance(dto);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("PutReservation")]
        public IActionResult PutReservation(ReservationUpdateDto dto)
        {
            var result = _reservationService.Update(dto);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteReservation")]
        public IActionResult DeleteReservation(ReservationDto dto)
        {
            var result = _reservationService.Delete(dto.ID);
            if(result.IsSuccess )
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
