﻿using Bussines.Abstract;
using Bussines.BaseEntities;
using Bussines.Validations;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAcess.Abstract;
using DataAcess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
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
        public IResult Add(TestmonialCreatDto dto, IFormFile PhotoUrl, string webRootPath)
        {
            var model = TestmonialCreatDto.ToTestmonial(dto);
           
            if (PhotoUrl == null || PhotoUrl.Length == 0)
            {
                var erors = new List<ValidationErrorModel>();
                erors.Add(new ValidationErrorModel { ErrorMessage = Uimessage.PHOTO_SELECTED });
                return new ErrorResult(erors.ValidationErrorMessagesWithNewLine());
            }

            model.PhotoUrl = PictureHelper.UploadImage(PhotoUrl, webRootPath);

            var validator = ValidationTool.Validate(new TestmonialValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _testmonialDal.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(TestmonialUpdateDto dto, IFormFile PhotoUrl, string webRootPath)
        {
            var model=TestmonialUpdateDto.ToTestmonial( dto);
            model.LastUpdatedDate = DateTime.Now;
            var value = GetById(dto.ID).Data;
            if (PhotoUrl == null)
            {
                model.PhotoUrl = value.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(PhotoUrl, webRootPath);
            }

            var validator = ValidationTool.Validate(new TestmonialValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _testmonialDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var model = GetById(id).Data;
            //var testmonialDelete = TestmonialDeleteDto.ToTestmonial(model);
            model.Deleted = id;

            _testmonialDal.Update(model);
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

        public IDataResult<Testmonial> GetById(int id)
        {
            var model = _testmonialDal.GetById(id);

            return new SuccessDataResult<Testmonial>(model);
        }

        public IResult Update(Testmonial entity)
        {
            entity.LastUpdatedDate = DateTime.Now;
            _testmonialDal.Update(entity);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }
    }
}
