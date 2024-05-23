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
    public interface IPositionService
    {
        IResult Add(PositionCreateDto dto);

        IResult Update(PositionUpdateDto dto);

        IResult Delete(int id);

        IDataResult<List<PositionDto>> GetAll();

        IDataResult<Position>GetById(int id);
    }
}
