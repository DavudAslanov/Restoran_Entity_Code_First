﻿using Entities.Concrete.TableModels;

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

        public static Rezervation ToReservation(ReservationDto dto)
        {
            Rezervation reservation = new Rezervation()
            {
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
