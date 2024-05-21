namespace Entities.Concrete.Dtos
{
    public class TeamsDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public int PositionID { get; set; }

        public bool IsHomePage { get; set; }
        public string PositionName {  get; set; }
    }
}
