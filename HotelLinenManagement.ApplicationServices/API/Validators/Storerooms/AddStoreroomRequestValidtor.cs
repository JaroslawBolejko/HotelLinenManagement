using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;

namespace HotelLinenManagement.ApplicationServices.API.Validators
{
   public class AddStoreroomRequestValidtor : AbstractValidator<AddStoreroomRequest>
    {
        public AddStoreroomRequestValidtor()
        {
            //withmessage pozwala na wpisanie własnego komunikatu ale dla mnie komunikat domyślny jest bardziej szczegółowy
            this.RuleFor(x => x.RoomNumber).InclusiveBetween(0, 10000).NotNull().WithMessage("WRONG_NUMBER_RANGE");
            this.RuleFor(x => x.StoreroomName).MaximumLength(250);
            
        }
    }
}
