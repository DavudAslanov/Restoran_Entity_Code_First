using Core.DataAcces.Abstract;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAcces.Concrete
{
    public class BaseRepository<Tentity, Tcontext> : IBaseInterfeys<Tentity>
        where Tentity : BaseEntity, new()
        where Tcontext : DbContext, new()
    {
        public void Add(Tentity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var Added = context.Entry(entity);
                Added.State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public void Delete(Tentity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var Deleted = context.Entry(entity);
                Deleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Tentity> GetAll(Expression<Func<Tentity, bool>>? filter = null)
        {
            using (Tcontext context = new Tcontext())
            {
                if (filter == null)
                {
                    return context.Set<Tentity>().ToList();
                }
                else
                {
                    return context.Set<Tentity>().Where(filter).ToList();
                }
            }
        }

        public Tentity GetById(int id)
        {
            using (Tcontext context = new Tcontext())
            {
                return context.Set<Tentity>().FirstOrDefault(x => x.ID == id);
            }
        }

        public void Update(Tentity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var Update = context.Entry(entity);
                Update.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
