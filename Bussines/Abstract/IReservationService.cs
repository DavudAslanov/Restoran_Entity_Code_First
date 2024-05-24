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
    public interface IReservationService
    {

        IResult Update(ReservationUpdateDto dto);
        IResult BookInAdvance(ReservationDto dto);

        IResult Delete(int id);

        IDataResult<List<ReservationDto>> GetAll();

        IDataResult<Rezervation> GetById(int id);
    }
}
