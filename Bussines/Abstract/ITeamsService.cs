using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface ITeamsService
    {
        IResult Add(TeamsCreateDto dto, IFormFile PhotoUrl, string webRootPath);

        IResult Update(TeamsUpdateDto dto, IFormFile PhotoUrl, string webRootPath);

        IResult Delete(int id);

        IDataResult<List<TeamsDto>> GetTeamWithTeamCategories();

        IDataResult<Team> GetById(int id);
    }
}
