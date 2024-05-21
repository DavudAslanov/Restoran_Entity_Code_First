using Bussines.Abstract;
using Bussines.Concrete;
using Bussines.Validations;
using DataAcces.Concrete;
using DataAcess.Abstract;
using DataAcess.Concrete;
using DataAcess.Context.SqlDbContext;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Restoran.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Dependesy Injection
            //FoodDal
            builder.Services.AddDbContext<AppDbcontext>();
            //Teamdal
            builder.Services.AddDbContext<AppDbcontext>();

            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();

            //Validation
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();
            builder.Services.AddScoped<IValidator<Contact>,ContactValidation>();
            builder.Services.AddScoped<IValidator<FoodCategory>,FoodCategoryValidation>();
            builder.Services.AddScoped<IValidator<Food>,FoodValidation>();
            builder.Services.AddScoped<IValidator<Position>, PositionValidation>();
            builder.Services.AddScoped<IValidator<Service>, ServiceValidation>();
            builder.Services.AddScoped<IValidator<Team>, TeamValidation>();
            builder.Services.AddScoped<IValidator<Testmonial>, TestmonialValidation>();
            builder.Services.AddScoped<IValidator<Rezervation>,ReservationValidation>();

            builder.Services.AddScoped<IFoodCategoryDal, FoodCategoryDal>();
            builder.Services.AddScoped<IFoodCategoryService,FoodCategoryManager>();

            builder.Services.AddScoped<IFoodDal, FoodDal>();
            builder.Services.AddScoped<IFoodService, FoodManager>();

            builder.Services.AddScoped<IContactDal, ContactDal>();
            builder.Services.AddScoped<IContactService, ContactManager>();

            builder.Services.AddScoped<IPositionDal, PositionDal>();
            builder.Services.AddScoped<IPositionService, PositionManager>();

            builder.Services.AddScoped<ITeamDal, TeamDal>();
            builder.Services.AddScoped<ITeamsService, TeamsManager>();

            builder.Services.AddScoped<IRezervationDal, RezervationDal>();
            builder.Services.AddScoped<IReservationService, ReservationManager>();

            builder.Services.AddScoped<IServiceDal, ServiceDal>();
            builder.Services.AddScoped<IService, ServiceManager>();

            builder.Services.AddScoped<ITestmonialDal, TestmonialDal>();
            builder.Services.AddScoped<ITestmonialService, TestmonialManager>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"Areas",

                    pattern:"{Area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name:default,
                    pattern:"{controller=Home}/{action=Index}/{id?}");
            });


            app.Run();
        }
    }
}
