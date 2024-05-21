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
    public interface IFoodService
    {
        IResult Add(FoodCreateDto dto);

        IResult Update(FoodUpdateDto dto);

        IResult Delete(int id);

        IDataResult<List<FoodDto>> GetFoodWithFoodCategories();

        IDataResult<FoodUpdateDto> GetById(int id);
    }
}
