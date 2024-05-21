using Entities.Concrete.TableModels;

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

        public static List<TeamsDto> ToTeams(Team team)
        {
            TeamsDto dto = new TeamsDto()
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
            List<TeamsDto> dtoList = new List<TeamsDto>();
            dtoList.Add(dto);
            return dtoList;
        }
    }
}
