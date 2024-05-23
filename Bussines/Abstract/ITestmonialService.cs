using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Bussines.Abstract
{
    public interface ITestmonialService
    {
        IResult Add(TestmonialCreatDto dto, IFormFile PhotoUrl, string webRootPath);

        IResult Update(TestmonialUpdateDto dto, IFormFile PhotoUrl, string webRootPath);

        IResult Delete(int id);

        IDataResult<List<TestmonialDto>> GetAll();

        IDataResult<Testmonial> GetById(int id);
    }
}
