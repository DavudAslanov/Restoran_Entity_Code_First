using Bussines.BaseEntities;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Bussines.Validations
{
    public class ContactValidation:AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Ad"))
                .MaximumLength(100)
                .WithMessage(Uimessage.GetMaxLengthMessage(100,"Ad"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Ad"));

            RuleFor(x => x.Email)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Email"))
                .MaximumLength(100)
                .WithMessage(Uimessage.GetMaxLengthMessage(100,"Email"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Email"));

            RuleFor(x=>x.Title) 
                .MinimumLength(4)
                .WithMessage(Uimessage.GetMinLengthMessage(4,"Başlıq"))
                .MaximumLength(150)
                .WithMessage(Uimessage.GetMaxLengthMessage(150,"Başlıq"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Başlıq"));

            RuleFor(x => x.Message)
                .MinimumLength(4)
                .WithMessage(Uimessage.GetMinLengthMessage(4,"Mesaj"))
                .MaximumLength(2000)
                .WithMessage(Uimessage.GetMaxLengthMessage(2000,"Mesaj"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Mesaj"));
        }
    }
}
