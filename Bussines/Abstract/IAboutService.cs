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
    public interface IAboutService
    {
        IResult Add(AboutCreateDto dto);

        IResult Update(AboutUpdateDto dto);

        IDataResult<List<AboutDto>> GetAll();

        IDataResult<AboutUpdateDto> GetById(int id);
    }
}
