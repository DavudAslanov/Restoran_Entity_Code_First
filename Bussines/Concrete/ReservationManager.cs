using Bussines.Abstract;
using Bussines.BaseEntities;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAcess.Abstract;
using Entities.Concrete.Dtos;

using Entities.Concrete.TableModels;

namespace Bussines.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IRezervationDal _reservationDal;
        public ReservationManager(IRezervationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _reservationDal.Update(data);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<List<Rezervation>> GetAll()
        {
            var result = _reservationDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<Rezervation>>(result);
        }

        public IDataResult<Rezervation> GetById(int id)
        {
            return new SuccessDataResult<Rezervation>(_reservationDal.GetById(id));
        }

        public IResult Update(ReservationUpdateDto dto)
        {
            var model = ReservationUpdateDto.ToReservation(dto);
            model.LastUpdatedDate = DateTime.Now;
            _reservationDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }
    }
}
