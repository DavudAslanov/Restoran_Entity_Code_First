using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Validations
{
    public class FoodValidation:AbstractValidator<Food>
    {
        public FoodValidation()
        {
            RuleFor(x=>x.Name)
                .MinimumLength(3)
                .WithMessage("Minimum Ad 3 Simvol Olmalıdır")
                .MaximumLength(150)
                .WithMessage("Maximum Ad uzunluğu 150 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş ola Bilməz");

            RuleFor(x=>x.Description)
                .MinimumLength(3)
                .WithMessage("Açıqlama Uzunluğu Minimum 3 Olmalıdır")
                .MaximumLength(200)
                .WithMessage("Açıqlama Uzunluğu Maximum 200 Olmalıdır ")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            //RuleFor(x => x.PhotoUrl)
            //    .NotEmpty()
            //    .WithMessage("Boş Ola Bilməz");
        }
    }
}
