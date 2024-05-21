using Core.DataAcces.Concrete;
using DataAcess.Abstract;
using DataAcess.Context.SqlDbContext;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Concrete
{
    public class TeamDal:BaseRepository<Team,AppDbcontext>,ITeamDal
    {
        private readonly AppDbcontext _context;
        public TeamDal(AppDbcontext appDbcontext)
        {
            _context = appDbcontext;
        }
        public List<TeamsDto> GetTeamWithTeamCategories()
        {
            var result = from Team in _context.Teams
                         where Team.Deleted == 0
                         join position in _context.Positions
                         on Team.PositionID equals position.ID
                         where position.Deleted == 0
                         select new TeamsDto
                         {
                             ID=Team.ID,
                             Name = Team.Name,
                             LastName= Team.LastName,
                             PositionID = position.ID,
                             InstagramUrl = Team.InstagramUrl,
                             TwitterUrl = Team.TwitterUrl,
                             FacebookUrl = Team.FacebookUrl,
                             IsHomePage = Team.IsHomePage,
                             PositionName=position.Name,
                         };
            return result.ToList();
        }
    }


}
