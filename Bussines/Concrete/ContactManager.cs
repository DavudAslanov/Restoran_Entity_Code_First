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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IValidator<Contact> _Validator;
        public ContactManager(IContactDal contactDal, IValidator<Contact> validator)
        {
            _contactDal = contactDal;
            _Validator = validator;
        }
        public IResult Add(ContactCreateDto dto)
        {
            var model = ContactCreateDto.ToContact(dto);

            var validator = ValidationTool.Validate(new ContactValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }

            _contactDal.Add(model);

            return  new SuccessResult(Uimessage.ADD_MESSAGE);
        }

        public IResult Update(ContactUpdateDto dto)
        {
            var model= ContactUpdateDto.ToContact(dto);
            model.LastUpdatedDate = DateTime.Now;
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
            _contactDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }

        public IDataResult<List<ContactDto>> GetAll()
        {
            var models = _contactDal.GetAll(x => x.Deleted == 0);
            List<ContactDto> aboutDtos = new List<ContactDto>();

            foreach (var model in models)
            {
                ContactDto dto = new ContactDto
                {
                    ID = model.ID,
                   Name = model.Name,
                   Email = model.Email,
                   Title = model.Title,
                   Message = model.Message,
                };
                aboutDtos.Add(dto);
            }

            return new SuccessDataResult<List<ContactDto>>(aboutDtos);
        }

        public IDataResult<Contact> GetById(int id)
        {
            var model = _contactDal.GetById(id);

            return new SuccessDataResult<Contact>(model);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _contactDal.Update(data);

            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _contactDal.Delete(data);

            return new SuccessResult(Uimessage.DELETED_MESSAGES);
        }
    }
}
