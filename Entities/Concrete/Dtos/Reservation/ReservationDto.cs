using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ReservationDto
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }

        public string Email { get; set; }

        public DateTime ReservationDate { get; set; }

        public byte PeopleCount { get; set; }

        public bool Iscontacted { get; set; }
        public string Message { get; set; }

        public static List<ReservationDto> ToReservation(Rezervation rezervation)
        {
            ReservationDto dto = new ReservationDto()
            {
               ID = rezervation.ID,
               CustomerName = rezervation.CustomerName,
               Email = rezervation.Email,
               PeopleCount = rezervation.PeopleCount,
               ReservationDate=rezervation.ReservationDate,
               Message=rezervation.Message,
               Iscontacted=rezervation.Iscontacted
            };
            List<ReservationDto> dtoList = new List<ReservationDto>();
            dtoList.Add(dto);
            return dtoList;
        }

    }
}
