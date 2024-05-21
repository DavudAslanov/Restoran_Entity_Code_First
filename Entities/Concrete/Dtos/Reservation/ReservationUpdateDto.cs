using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ReservationUpdateDto
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }

        public string Email { get; set; }

        public DateTime ReservationDate { get; set; }

        public byte PeopleCount { get; set; }

        public bool Iscontacted { get; set; }
        public string Message { get; set; }

        public static ReservationUpdateDto ToReservation(Rezervation rezervation)
        {
            ReservationUpdateDto dto = new()
            {
               ID=rezervation.ID,
               CustomerName=rezervation.CustomerName,
               Email=rezervation.Email,
               PeopleCount=rezervation.PeopleCount,
               ReservationDate=rezervation.ReservationDate,
               Iscontacted=rezervation.Iscontacted,
               Message=rezervation.Message
            };
            return dto;
        }
        public static  Rezervation ToReservation(ReservationUpdateDto dto)
        {
            Rezervation reservation = new Rezervation()
            {
                ID = dto.ID,
                CustomerName = dto.CustomerName,
                Email = dto.Email,
                PeopleCount = dto.PeopleCount,
                Iscontacted = dto.Iscontacted,
                Message = dto.Message,
                ReservationDate = dto.ReservationDate
            };
            return reservation;
        }
    }
}
