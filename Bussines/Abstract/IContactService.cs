using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface IContactService
    {
        IResult Add(ContactCreateDto dto);

        IResult Update(ContactUpdateDto dto);   

        IResult Delete(int id);

        IDataResult<List<ContactDto>> GetAll();

        IDataResult<Contact> GetById(int id);


    }
}
