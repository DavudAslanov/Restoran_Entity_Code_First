using Bussines.Abstract;
using Bussines.BaseEntities;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAcess.Abstract;
using Entities.Concrete.Dtos;

using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IRezervationDal _reservationDal;
        private readonly IValidator<Rezervation> _Validator;
        public ReservationManager(IRezervationDal reservationDal, IValidator<Rezervation> validator)
        {
            _reservationDal = reservationDal;
            _Validator = validator;
        }

        public IResult Delete(int id)
        {
            var model = GetById(id).Data;
            var positionDelete = ReservationDeleteDto.ToReservation(model);
            positionDelete.Deleted = id;

            _reservationDal.Update(positionDelete);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<List<ReservationDto>> GetAll()
        {
            var models = _reservationDal.GetAll(x => x.Deleted == 0);
            List<ReservationDto> positionDtos = new List<ReservationDto>();

            foreach (var model in models)
            {
                ReservationDto dto = new ReservationDto
                {
                   ID= model.ID,
                   CustomerName= model.CustomerName,
                   Email= model.Email,
                   Iscontacted= model.Iscontacted,
                   Message= model.Message,
                   PeopleCount = model.PeopleCount,
                   ReservationDate= model.ReservationDate,
                };
                positionDtos.Add(dto);
            }
            return new SuccessDataResult<List<ReservationDto>>(positionDtos);
        }

        public IDataResult<ReservationUpdateDto> GetById(int id)
        {
            var model = _reservationDal.GetById(id);
            var reservationUpdateDto = ReservationUpdateDto.ToReservation(model);
            return new SuccessDataResult<ReservationUpdateDto>(reservationUpdateDto);
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
