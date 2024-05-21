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
                .WithMessage("Minimum Ad 3 Simvol Olmalıdır")
                .MaximumLength(150)
                .WithMessage("Maximum Ad 150 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz!");

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage("Minimum Açıqlama 3 Simvol Olmalıdır")
                .MaximumLength(2000)
                .WithMessage("Maximum Açıqlama 2000 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz!");

            RuleFor(x => x.IconName)
            .MinimumLength(3)
            .WithMessage("Minimum İcon Adı 3 Simvol Olmalıdır")
            .MaximumLength(100)
            .WithMessage("Maximum İcon Adı 2000 Simvol Olmalıdır")
            .NotEmpty()
            .WithMessage("Boş Ola Bilməz!");


        }
    }
}
