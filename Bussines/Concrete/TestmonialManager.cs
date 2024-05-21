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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class TestmonialManager : ITestmonialService
    {

        private readonly ITestmonialDal _testmonialDal;
        private readonly IValidator<Testmonial> _Validator;
        public TestmonialManager(ITestmonialDal testmonialDal, IValidator<Testmonial> validator)
        {
            _testmonialDal = testmonialDal;
            _Validator = validator;
        }
        public IResult Add(TestmonialCreatDto dto)
        {
            var model = TestmonialCreatDto.ToTestmonial(dto);
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
            _testmonialDal.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(TestmonialUpdateDto dto)
        {
            var model=TestmonialUpdateDto.ToTestmonial( dto);
            model.LastUpdatedDate = DateTime.Now;
            _testmonialDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _testmonialDal.Update(data);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<List<Testmonial>> GetAll()
        {
            var result = _testmonialDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<Testmonial>>(result);
        }

        public IDataResult<Testmonial> GetById(int id)
        {
            return new SuccessDataResult<Testmonial>(_testmonialDal.GetById(id));
        }

        public IResult Update(Testmonial entity)
        {
            entity.LastUpdatedDate = DateTime.Now;
            _testmonialDal.Update(entity);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }
    }
}
