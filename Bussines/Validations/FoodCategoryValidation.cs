using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Validations
{
    public class FoodCategoryValidation:AbstractValidator<FoodCategory>
    {
        public FoodCategoryValidation()
        {
            RuleFor(x=>x.Name)
                .MinimumLength(3)
                .WithMessage("Minimum Ad 3 Simvol Olmalıdır")
                .MaximumLength(150)
                .WithMessage("Maximum 150 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x=>x.IconName)
                .MinimumLength(3)
                .WithMessage("Minimum IconName 3 Simvol olmalıdır")
                .MaximumLength(200)
                .WithMessage("Maximum Icon Adı 200 olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Olmalıdır");
        }
    }
}
