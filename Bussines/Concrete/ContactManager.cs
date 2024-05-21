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

            var validator= _Validator.Validate(model);

            string errorMessage = "";
            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }
            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _contactDal.Add(model);

            return  new SuccessResult(Uimessage.ADD_MESSAGE);
        }

        public IResult Update(ContactUpdateDto dto)
        {
            var model= ContactUpdateDto.ToContact(dto);
            model.LastUpdatedDate = DateTime.Now;
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

        public IDataResult<ContactUpdateDto> GetById(int id)
        {
            var model = _contactDal.GetById(id);

            var contactUpdateDto = ContactUpdateDto.ToContact(model);

            return new SuccessDataResult<ContactUpdateDto>(contactUpdateDto);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var model=ContactDeleteDto.ToContact(data);
            model.Deleted = id;
            _contactDal.Update(model);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }
    }
}
