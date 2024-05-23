using Bussines.Abstract;
using Bussines.BaseEntities;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAcess.Abstract;
using DataAcess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
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
        public IResult Add(ServiceCreateDto dto, IFormFile IconName, string webRootPath)
        {
            var model=ServiceCreateDto.ToService(dto);

            model.IconName = PictureHelper.UploadImage(IconName, webRootPath);

            var validator = _Validator.Validate(model);

            List<string> errorMessages = new List<string>();
            foreach (var item in validator.Errors)
            {
                errorMessages.Add(item.ErrorMessage);
            }
            if (!validator.IsValid)
            {
                string erorMessage = string.Join(", ", errorMessages);
                return new ErrorResult(erorMessage);
            }
            _serviceDal.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(ServiceUpdateDto dto, IFormFile IconName, string webRootPath)
        {
            var model=ServiceUpdateDto.ToService( dto);
            model.LastUpdatedDate = DateTime.Now;
            var value = GetById(dto.ID).Data;
            if (IconName == null)
            {
                model.IconName = value.IconName;
            }
            else
            {
                model.IconName = PictureHelper.UploadImage(IconName, webRootPath);
            }
            var validator = _Validator.Validate(model);
            List<string> errorMessages = new List<string>();
            foreach (var item in validator.Errors)
            {
                errorMessages.Add(item.ErrorMessage);
            }
            if (!validator.IsValid)
            {
                string erorMessage = string.Join(", ", errorMessages);
                return new ErrorResult(erorMessage);
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
            //var serviceUpdateDto = ServiceUpdateDto.ToService(model);

            return new SuccessDataResult<Service>(model);
        }

      
    }
}
