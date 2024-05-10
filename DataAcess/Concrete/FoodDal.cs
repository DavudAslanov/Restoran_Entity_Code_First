using Core.DataAcces.Concrete;
using DataAcess.Context.SqlDbContext;
using Entities.Concrete.TableModels;

namespace DataAcess.Concrete
{
    public class FoodDal:BaseRepository<Food, AppDbcontext> { }


}
