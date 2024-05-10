using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Context.SqlDbContext
{
    public class AppDbcontext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Localhost;Initial Catalog= MyDatabaseDB ;Integrated Security = true;");
        }
        public DbSet<About> Abouts { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodCategory> FoodCategories { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Rezervation> Rezervations{get; set; }

        public DbSet<Service> Services{ get; set; }

        public DbSet<Team>Teams{ get; set; }       

        public DbSet<Testmonial>Testmonials{get; set; }
    }
}
