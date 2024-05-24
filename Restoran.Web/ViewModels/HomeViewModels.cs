using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Restoran.Web.ViewModels
{
    public class HomeViewModel
    {
        public List<AboutDto> AboutsDto { get; set; }

        public List<FoodDto> FoodsDto { get; set; }

        public List<TestmonialDto> TestmonialsDto { get; set;}

        public List<FoodCategoryDto> FoodCategoriesDto { get; set;}

        public List<TeamsDto> TeamsDto { get; set; }

        public List<PositionDto> PositionsDto { get; set; }

        public List<ServiceDto> ServicesDto { get; set; }
        public ReservationDto ReservationDto { get; set; }

    }
}
