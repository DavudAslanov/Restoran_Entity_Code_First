using Core.DataAcces.Concrete;
using DataAcess.Abstract;
using DataAcess.Context.SqlDbContext;
using Entities.Concrete.TableModels;

namespace DataAcess.Concrete
{
    public class TestmonialDal:BaseRepository<Testmonial,AppDbcontext>,ITestmonialDal { }


}
