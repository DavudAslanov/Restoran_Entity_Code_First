using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Validations
{
    public class AboutValidation:AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage("3 simvoldan az Daxil Edilə bilməz")
                .MaximumLength(2000)
                .WithMessage("2000 Simvoldan Artıq Ola Bilməz")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz!");
        }
    }
}
