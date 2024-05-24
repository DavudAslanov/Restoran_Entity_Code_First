using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Restoran.Web.ViewModels
{
    public class AboutViewModel
    {
        public List<AboutDto> AboutsDto { get; set; }

        public List<TeamsDto> TeamsDto { get; set; }
    }
}
