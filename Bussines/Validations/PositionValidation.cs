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
                .WithMessage("Ad Minimum 3 Simvol olmalıdır")
                .MaximumLength(100)
                .WithMessage("Maximum 100 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");
        }
    }
}
