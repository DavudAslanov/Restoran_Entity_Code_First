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
                .WithMessage("Minimum Ad 3 Simvol Olmalıdır")
                .MaximumLength(50)
                .WithMessage("Maximum Ad 100 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.LastName)
                .MinimumLength(3)
                .WithMessage("Minimum Soyad 3 Simvol Olmalıdır")
                .MaximumLength(50)
                .WithMessage("Maximum Soyad 100 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.FeedBack)
                .MinimumLength(3)
                .WithMessage("Minimum Açıqlama 3 Simvol Olmalıdır")
                .MaximumLength(2000)
                .WithMessage("Maximum Açıqlama 150 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            RuleFor(x => x.PhotoUrl)
                .MinimumLength(3)
                .WithMessage("Minimum şəkil 3 Simvol Olmalıdır")
                .MaximumLength(150)
                .WithMessage("Maximum şəkil 150 Simvol Olmalıdır")
                .NotEmpty()
                .WithMessage("Boş Ola Bilməz");

            
        }
    }
}
