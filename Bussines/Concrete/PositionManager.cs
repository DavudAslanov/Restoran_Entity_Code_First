using Bussines.Abstract;
using Bussines.BaseEntities;
using Bussines.Validations;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAcess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Concrete
{
    public class PositionManager : IPositionService
    {

        private readonly IPositionDal _positionDal;
        private readonly IValidator<Position> _Validator;
        public PositionManager(IPositionDal positionDal, IValidator<Position> validator)
        {
            _positionDal = positionDal;
            _Validator = validator;
        }
        public IResult Add(PositionCreateDto dto)
        {
            var model = PositionCreateDto.ToPosition(dto);

            var validator = ValidationTool.Validate(new PositionValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _positionDal.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(PositionUpdateDto dto)
        {
            var model= PositionUpdateDto.ToPosition(dto);
            model.LastUpdatedDate = DateTime.Now;

            var validator = ValidationTool.Validate(new PositionValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _positionDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }
        public IResult Delete(int id)
        {
            var model = GetById(id).Data;

            model.Deleted = id;

            _positionDal.Update(model);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<List<PositionDto>> GetAll()
        {
            var models = _positionDal.GetAll(x => x.Deleted == 0);
            List<PositionDto> positionDtos = new List<PositionDto>();

            foreach (var model in models)
            {
                PositionDto dto = new PositionDto
                {
                    ID = model.ID,
                    Name= model.Name,
                };
                positionDtos.Add(dto);
            }
            return new SuccessDataResult<List<PositionDto>>(positionDtos);
        }

        public IDataResult<Position> GetById(int id)
        {
            var model = _positionDal.GetById(id);

            return new SuccessDataResult<Position>(model);
        }

      
    }
}
