using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens;

namespace HotelLinenManagement.ApplicationServices.API.Validators.HotelLinens
{
    public class AddHotelLinenRequestValidator : AbstractValidator<AddHotelLinenRequest>
    {
        public AddHotelLinenRequestValidator()
        {
            this.RuleFor(x => x.LinenName).NotNull().NotEmpty().Length(0, 250);
            this.RuleFor(x => x.LinenAmount).NotEmpty().InclusiveBetween(1,10000);
            this.RuleFor(x => x.Size).NotNull().NotEmpty().Length(0,250);
            this.RuleFor(x => x.Color).NotNull().NotEmpty().Length(0,250);
            this.RuleFor(x => x.HotelId).NotNull().NotEmpty();
            this.RuleFor(x => x.StoreroomId).NotNull().NotEmpty();
            this.RuleFor(x => x.Description).NotNull().NotEmpty().Length(0, 250);
            this.RuleFor(x => x.LinienWeight).NotEmpty().InclusiveBetween(0,10);
        }
    }
}
