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
    public class TeamValidation:AbstractValidator<Team>
    {
        public TeamValidation()
        {
            RuleFor(x=>x.Name)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3,"Ad"))
                .MaximumLength(50)
                .WithMessage(Uimessage.GetMaxLengthMessage(50,"Ad"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Ad"));

            RuleFor(x=>x.LastName) 
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3, "Soyad"))
                .MaximumLength(50)
                .WithMessage(Uimessage.GetMaxLengthMessage(50, "Soyad"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Soyad"));

            RuleFor(x=>x.FacebookUrl) 
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3, "Facebook"))
                .MaximumLength(150)
                .WithMessage(Uimessage.GetMaxLengthMessage(150, "Facebook"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Facebook"));

            RuleFor(x => x.TwitterUrl)
                .MinimumLength(3)
                .WithMessage(Uimessage.GetMinLengthMessage(3, "Twitter"))
                .MaximumLength(150)
                .WithMessage(Uimessage.GetMaxLengthMessage(150, "Twitter"))
                .NotEmpty()
                .WithMessage(Uimessage.GetRequiredMessage("Twitter"));

            RuleFor(x => x.InstagramUrl)
              .MinimumLength(3)
              .WithMessage(Uimessage.GetMinLengthMessage(3, "Instagram"))
              .MaximumLength(150)
              .WithMessage(Uimessage.GetMaxLengthMessage(150, "Instagram"))
              .NotEmpty()
              .WithMessage(Uimessage.GetRequiredMessage("Instagram"));
        }
    }
}
