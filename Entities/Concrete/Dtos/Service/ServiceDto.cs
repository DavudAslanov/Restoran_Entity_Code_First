namespace Entities.Concrete.Dtos
{
    public class ServiceDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsHomePage { get; set; }

        public string IconName { get; set; }
    }
}
