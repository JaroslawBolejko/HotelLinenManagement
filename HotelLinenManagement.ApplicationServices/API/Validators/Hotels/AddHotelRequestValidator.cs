using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;

namespace HotelLinenManagement.ApplicationServices.API.Validators.Hotels
{
    public class AddHotelRequestValidator : AbstractValidator<AddHotelRequest>
    {
        public AddHotelRequestValidator()
        {
            this.RuleFor(x => x.HotelName).NotNull().NotEmpty().Length(1, 250);
        }
    }
}
