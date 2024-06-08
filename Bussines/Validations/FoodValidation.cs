using Bussines.BaseEntities;
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
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Ad"))
                .MaximumLength(150)
                .WithMessage(Uimessage.GetMaxLengthMessage(150,"Ad"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Ad"));

            RuleFor(x=>x.Description)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Açıqlama"))
                .MaximumLength(200)
                .WithMessage(Uimessage.GetMaxLengthMessage(200,"Açıqlama"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Açıqlama"));

            RuleFor(x => x.Price)
              .GreaterThanOrEqualTo(1)
                  .WithMessage(Uimessage.GetMinLengthMessage(1, "Qiymət"));
        }
    }
}
