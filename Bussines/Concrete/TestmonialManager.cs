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
            var model = GetById(id).Data;
            var testmonialDelete = TestmonialDeleteDto.ToTestmonial(model);
            testmonialDelete.Deleted = id;

            _testmonialDal.Update(testmonialDelete);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<List<TestmonialDto>> GetAll()
        {
            var models = _testmonialDal.GetAll(x => x.Deleted == 0);

            List<TestmonialDto> serviceDtos = new List<TestmonialDto>();

            foreach (var model in models)
            {
                TestmonialDto dto = new TestmonialDto
                {
                    ID=model.ID,
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    FeedBack=model.FeedBack,
                    PhotoUrl=model.PhotoUrl,
                };
                serviceDtos.Add(dto);
            }
            return new SuccessDataResult<List<TestmonialDto>>(serviceDtos);
        }

        public IDataResult<TestmonialUpdateDto> GetById(int id)
        {
            var model = _testmonialDal.GetById(id);
            var testmonialUpdate = TestmonialUpdateDto.ToTestmonial(model);
            return new SuccessDataResult<TestmonialUpdateDto>(testmonialUpdate);
        }

        public IResult Update(Testmonial entity)
        {
            entity.LastUpdatedDate = DateTime.Now;
            _testmonialDal.Update(entity);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }
    }
}
