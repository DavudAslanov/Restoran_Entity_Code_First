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
    public class PositionValidation:AbstractValidator<Position>
    {
        public PositionValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Ad"))
                .MaximumLength(100)
                .WithMessage(Uimessage.GetMaxLengthMessage(100,"Ad"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Ad"));
        }
    }
}
