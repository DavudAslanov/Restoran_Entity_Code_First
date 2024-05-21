using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validations
{
    public class TeamValidation:AbstractValidator<Team>
    {
        public TeamValidation()
        {
            RuleFor(x=>x.Name)
                .MinimumLength(3)
                .WithMessage("Minimum Ad 3 Simvol Olmalıdır")
                .MaximumLength(50)
                .WithMessage("Maximum Ad 50 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x=>x.LastName) 
                .MinimumLength(3)
                .WithMessage("Minimum Soyad 3 Simvol Olmalıdır")
                .MaximumLength(50)
                .WithMessage("Maximum Soyad 50 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x=>x.FacebookUrl) 
                .MinimumLength(3)
                .WithMessage("Minimum Facebook 3 Simvol Olmalıdır")
                .MaximumLength(150)
                .WithMessage("Maximum Facebook 150 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.TwitterUrl)
                .MinimumLength(3)
                .WithMessage("Minimum Twitter 3 Simvol Olmalıdır")
                .MaximumLength(150)
                .WithMessage("Maximum Twitter 150 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.InstagramUrl)
              .MinimumLength(3)
              .WithMessage("Minimum Instagram 3 Simvol Olmalıdır")
              .MaximumLength(150)
              .WithMessage("Maximum Instagram 150 Simvol Olmalıdır")
              .NotEmpty()
              .WithMessage("Boş Ola Bilməz");
        }
    }
}
