using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TeamsCreateDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public int PositionID { get; set; }

        public bool IsHomePage { get; set; }

        public static Team ToTeams(TeamsCreateDto dto)
        {
            Team team = new Team()
            {
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
