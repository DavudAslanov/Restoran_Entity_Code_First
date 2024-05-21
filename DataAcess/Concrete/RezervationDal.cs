using Core.DataAcces.Concrete;
using DataAcess.Abstract;
using DataAcess.Context.SqlDbContext;
using Entities.Concrete.TableModels;

namespace DataAcess.Concrete
{
    public class RezervationDal: BaseRepository<Rezervation,AppDbcontext>,IRezervationDal { }

}
