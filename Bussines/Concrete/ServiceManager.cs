using Bussines.Abstract;
using Bussines.BaseEntities;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAcess.Abstract;
using DataAcess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var validator = _Validator.Validate(model);

            string errorMessage = "";
            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }
            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _serviceDal.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(ServiceUpdateDto dto)
        {
            var model=ServiceUpdateDto.ToService( dto);
            model.LastUpdatedDate = DateTime.Now;
            _serviceDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var model = GetById(id).Data;

            var serviceDelete = ServiceDeleteDto.ToService(model);
            serviceDelete.Deleted = id;

            _serviceDal.Update(serviceDelete);
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

        public IDataResult<ServiceUpdateDto> GetById(int id)
        {
            var model = _serviceDal.GetById(id);
            var serviceUpdateDto = ServiceUpdateDto.ToService(model);

            return new SuccessDataResult<ServiceUpdateDto>(serviceUpdateDto);
        }

      
    }
}
