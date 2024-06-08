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
    public class ReservationValidation:AbstractValidator<Rezervation>
    {
        public ReservationValidation()
        {
            RuleFor(x => x.CustomerName)
              .MinimumLength(3)
              .WithMessage(Uimessage.GetMinLengthMessage(3,"Ad"))
              .MaximumLength(50)
              .WithMessage(Uimessage.GetMaxLengthMessage(50,"Ad"))
              .NotEmpty()
              .WithMessage(Uimessage.GetRequiredMessage("Ad"));

            RuleFor(x => x.Email)
                .MinimumLength(5)
                .WithMessage(Uimessage.GetMinLengthMessage(5,"Email"))
                .MaximumLength(50)
                .WithMessage(Uimessage.GetMaxLengthMessage(50,"Email"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Email"));

            RuleFor(x => x.ReservationDate)
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Rezervasiya"));

            RuleFor(x => x.PeopleCount)
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Adam Sayı"));

            RuleFor(x => x.Message)
              .MinimumLength(3)
              .WithMessage(Uimessage.GetMinLengthMessage(3,"Mesaj"))
              .MaximumLength(150)
              .WithMessage(Uimessage.GetMaxLengthMessage(150,"Mesaj"))
              .NotEmpty()
              .WithMessage(Uimessage.GetRequiredMessage("Mesaj"));

        }
    }
}
