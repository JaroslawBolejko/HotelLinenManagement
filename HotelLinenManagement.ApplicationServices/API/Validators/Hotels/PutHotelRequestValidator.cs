using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;

namespace HotelLinenManagement.ApplicationServices.API.Validators.Hotels
{
    public class PutHotelRequestValidator : AbstractValidator<PutHotelByIdRequest>
    {
        public PutHotelRequestValidator()
        {
            this.RuleFor(x => x.Id).NotNull().NotEmpty();
            this.RuleFor(x => x.HotelName).NotNull().NotEmpty().Length(1, 250);
        }
    }
}
