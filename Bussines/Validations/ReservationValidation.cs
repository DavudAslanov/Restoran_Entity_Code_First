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
              .WithMessage("Minimum Ad 3 Simvol Olmalıdır")
              .MaximumLength(50)
              .WithMessage("Maximum Ad 50 Simvol Olmalıdır")
              .NotEmpty()
              .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.Email)
                .MinimumLength(5)
                .WithMessage("Minimum Email 5 Simvol Olmalıdır")
                .MaximumLength(50)
                .WithMessage("Maximum Soyad 50 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.ReservationDate)
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.PeopleCount)
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.Message)
              .MinimumLength(3)
              .WithMessage("Minimum Messaj 3 Simvol Olmalıdır")
              .MaximumLength(150)
              .WithMessage("Maximum Messaj 150 Simvol Olmalıdır")
              .NotEmpty()
              .WithMessage("Boş Ola Bilməz");

        }
    }
}
