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
    public interface ITestmonialService
    {
        IResult Add(TestmonialCreatDto dto);

        IResult Update(TestmonialUpdateDto dto);

        IResult Delete(int id);

        IDataResult<List<Testmonial>> GetAll();

        IDataResult<Testmonial> GetById(int id);
    }
}
