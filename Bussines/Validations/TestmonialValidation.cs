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
    public class TestmonialValidation:AbstractValidator<Testmonial>
    {
        public TestmonialValidation()
        {
            RuleFor(x => x.FirstName)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Ad"))
                .MaximumLength(50)
                .WithMessage(Uimessage.GetMaxLengthMessage(50,"Ad"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Ad"));

            RuleFor(x => x.LastName)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3, "Soyad"))
                .MaximumLength(50)
                .WithMessage(Uimessage.GetMaxLengthMessage(50, "Soyad"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Soyad"));

            RuleFor(x => x.FeedBack)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Açıqlama"))
                .MaximumLength(2000)
                .WithMessage(Uimessage.GetMaxLengthMessage(50, "Açıqlama"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Açıqlama"));

            RuleFor(x => x.PhotoUrl)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3, "şəkil"))
                .MaximumLength(150)
                .WithMessage(Uimessage.GetMaxLengthMessage(50, "şəkil"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("şəkil"));

            
        }
    }
}
