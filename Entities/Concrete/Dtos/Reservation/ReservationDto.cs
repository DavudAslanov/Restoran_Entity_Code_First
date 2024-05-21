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

        
    }
}
