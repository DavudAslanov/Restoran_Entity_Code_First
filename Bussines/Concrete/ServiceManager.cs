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
            var data = GetById(id).Data;

            data.Deleted = id;

            _serviceDal.Update(data);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<List<Service>> GetAll()
        {
            var result = _serviceDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<Service>>(result);
        }

        public IDataResult<Service> GetById(int id)
        {
            return new SuccessDataResult<Service>(_serviceDal.GetById(id));
        }

      
    }
}
