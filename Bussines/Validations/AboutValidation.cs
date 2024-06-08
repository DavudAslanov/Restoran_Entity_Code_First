using Bussines.BaseEntities;
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
                .WithMessage(Uimessage.GetMinLengthMessage(3, "Açıqlama"))
                .MaximumLength(2000)
                .WithMessage(Uimessage.GetMaxLengthMessage(2000, "Açıqlama"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Açıqlama"));
        }
    }
}
