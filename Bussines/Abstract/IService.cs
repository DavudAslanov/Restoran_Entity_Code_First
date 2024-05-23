using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface IService
    {
        IResult Add(ServiceCreateDto dto, IFormFile IconName, string webRootPath);

        IResult Update(ServiceUpdateDto dto, IFormFile IconName, string webRootPath);

        IResult Delete(int id);

        IDataResult<List<ServiceDto>> GetAll();

        IDataResult<Service> GetById(int id);
    }
}
