using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;

namespace HotelLinenManagement.ApplicationServices.API.Validators.Storerooms
{
    public class PutStoreroomRequestValidator : AbstractValidator<PutStoreroomsByIdRequest>
    {
        public PutStoreroomRequestValidator()
        {
            this.RuleFor(x => x.Id).NotNull().NotEmpty();
            this.RuleFor(x => x.RoomNumber).InclusiveBetween(0, 10000).NotNull().WithMessage("WRONG_NUMBER_RANGE.Number must be beetwen 0 and 10000.");
            this.RuleFor(x => x.StoreroomName).MaximumLength(250);
        }
                            
    }
}
