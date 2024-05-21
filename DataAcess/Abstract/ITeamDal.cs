using Core.DataAcces.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAcess.Abstract
{
    public interface ITeamDal:IBaseInterfeys<Team>
    {
        List<TeamsDto> GetTeamWithTeamCategories();
    }


}
