using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validations
{
    public class ContactValidation:AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(" Ad Minimum 4 Simvol olmalıdır")
                .MaximumLength(100)
                .WithMessage("Ad Maximum 100 Simvol olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.Email)
                .MinimumLength(3)
                .WithMessage("Email Minimum 3 Simvol Olmalıdır")
                .MaximumLength(100)
                .WithMessage("Email Maximum 100 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x=>x.Title) 
                .MinimumLength(4)
                .WithMessage(" Başlıq Minimum 4 Simvol Olmalıdır")
                .MaximumLength(150)
                .WithMessage("Maximum 150 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz!");

            RuleFor(x => x.Message)
                .MinimumLength(4)
                .WithMessage("Mesaj Minimum 4 Simvol Olmalıdır")
                .MaximumLength(2000)
                .WithMessage("Mesaj Maximum 2000 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");
        }
    }
}
