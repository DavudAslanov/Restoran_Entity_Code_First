using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TeamsUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public int PositionID { get; set; }

        public bool IsHomePage { get; set; }

        public static TeamsUpdateDto ToTeams(Team team)
        {
            TeamsUpdateDto dto = new()
            {
               ID=team.ID,
               Name=team.Name,
               LastName=team.LastName,
               FacebookUrl=team.FacebookUrl,
               TwitterUrl=team.TwitterUrl,
               InstagramUrl=team.InstagramUrl,
               PositionID=team.PositionID,
               IsHomePage=team.IsHomePage,
            };
            return dto;
        }
        public static Team ToTeams(TeamsUpdateDto dto)
        {
            Team team = new Team()
            {
                ID = dto.ID,
                Name = dto.Name,
                LastName = dto.LastName,
                FacebookUrl = dto.FacebookUrl,
                TwitterUrl = dto.TwitterUrl,
                InstagramUrl = dto.InstagramUrl,
                PositionID = dto.PositionID,
                IsHomePage = dto.IsHomePage,
            };
            return team;
        }
    }
}
