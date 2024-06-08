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
    public class ServiceManager : IService
    {

        private readonly IServiceDal _serviceDal;
        private readonly IValidator<Service> _Validator;
        public ServiceManager(IServiceDal serviceDal, IValidator<Service> validator)
        {
            _serviceDal = serviceDal;
            _Validator = validator;
        }
        public IResult Add(ServiceCreateDto dto)
        {
            var model=ServiceCreateDto.ToService(dto);

            var validator = ValidationTool.Validate(new ServiceValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _serviceDal.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(ServiceUpdateDto dto)
        {
            var model=ServiceUpdateDto.ToService( dto);
            model.LastUpdatedDate = DateTime.Now;
            var value = GetById(dto.ID).Data;

            var validator = ValidationTool.Validate(new ServiceValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _serviceDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var model = GetById(id).Data;

            model.Deleted = id;

            _serviceDal.Update(model);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<List<ServiceDto>> GetAll()
        {
            var models = _serviceDal.GetAll(x => x.Deleted == 0);
            List<ServiceDto> serviceDtos = new List<ServiceDto>();

            foreach (var model in models)
            {
                ServiceDto dto = new ServiceDto
                {
                   ID= model.ID,
                   Name= model.Name,
                   Description= model.Description,
                   IconName= model.IconName,
                   IsHomePage= model.IsHomePage,
                };
                serviceDtos.Add(dto);
            }

            return new SuccessDataResult<List<ServiceDto>>(serviceDtos);
        }

        public IDataResult<Service> GetById(int id)
        {
            var model = _serviceDal.GetById(id);

            return new SuccessDataResult<Service>(model);
        }

      
    }
}
