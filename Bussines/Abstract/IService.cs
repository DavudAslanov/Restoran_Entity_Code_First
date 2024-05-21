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
    public interface IService
    {
        IResult Add(ServiceCreateDto dto);

        IResult Update(ServiceUpdateDto dto);

        IResult Delete(int id);

        IDataResult<List<Service>> GetAll();

        IDataResult<Service> GetById(int id);
    }
}
