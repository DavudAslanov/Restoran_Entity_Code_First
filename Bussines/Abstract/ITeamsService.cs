using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface ITeamsService
    {
        IResult Add(TeamsCreateDto dto);

        IResult Update(TeamsUpdateDto dto);

        IResult Delete(int id);

        IDataResult<List<TeamsDto>> GetTeamWithTeamCategories();

        IDataResult<Team> GetById(int id);
    }
}
