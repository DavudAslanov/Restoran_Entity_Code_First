
using Bussines.Abstract;
using Bussines.Concrete;
using Bussines.Validations;
using DataAcces.Concrete;
using DataAcess.Abstract;
using DataAcess.Concrete;
using DataAcess.Context.SqlDbContext;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using FluentValidation;

namespace Restoran.WebApI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbcontext>()
             .AddIdentity<ApplicationUser, ApplicationRole>()
             .AddEntityFrameworkStores<AppDbcontext>();

            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();

            //Validation
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();
            builder.Services.AddScoped<IValidator<Contact>, ContactValidation>();
            builder.Services.AddScoped<IValidator<FoodCategory>, FoodCategoryValidation>();
            builder.Services.AddScoped<IValidator<Food>, FoodValidation>();
            builder.Services.AddScoped<IValidator<Position>, PositionValidation>();
            builder.Services.AddScoped<IValidator<Service>, ServiceValidation>();
            builder.Services.AddScoped<IValidator<Team>, TeamValidation>();
            builder.Services.AddScoped<IValidator<Testmonial>, TestmonialValidation>();
            builder.Services.AddScoped<IValidator<Rezervation>, ReservationValidation>();

            builder.Services.AddScoped<IFoodCategoryDal, FoodCategoryDal>();
            builder.Services.AddScoped<IFoodCategoryService, FoodCategoryManager>();

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

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
