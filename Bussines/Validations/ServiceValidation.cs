using Bussines.BaseEntities;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validations
{
    public class ServiceValidation : AbstractValidator<Service>
    {
        public ServiceValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Ad"))
                .MaximumLength(150)
                .WithMessage(Uimessage.GetMaxLengthMessage(150,"Ad"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Ad"));

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Açıqlama"))
                .MaximumLength(2000)
                .WithMessage(Uimessage.GetMaxLengthMessage(2000,"Açıqlama"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Açıqlama"));

            RuleFor(x => x.IconName)
            .MinimumLength(3)
            .WithMessage(Uimessage.GetMinLengthMessage(3,"Icon Adı"))
            .MaximumLength(100)
            .WithMessage(Uimessage.GetMaxLengthMessage(100, "Icon Adı"))
            .NotEmpty()
            .WithMessage(Uimessage.GetRequiredMessage("Icon Adı"));


        }
    }
}
