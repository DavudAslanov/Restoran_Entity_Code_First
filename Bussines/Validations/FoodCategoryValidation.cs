using Bussines.BaseEntities;
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
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Ad"))
                .MaximumLength(150)
                .WithMessage(Uimessage.GetMaxLengthMessage(150,"Ad"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Ad"));

            RuleFor(x=>x.IconName)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Icon Adı"))
                .MaximumLength(200)
                .WithMessage(Uimessage.GetMaxLengthMessage(200, "Icon Adı"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Icon Adı"));
        }
    }
}
