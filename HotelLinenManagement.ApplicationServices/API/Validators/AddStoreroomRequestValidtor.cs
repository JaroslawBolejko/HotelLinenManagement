using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;

namespace HotelLinenManagement.ApplicationServices.API.Validators
{
   public class AddStoreroomRequestValidtor : AbstractValidator<AddStoreroomRequest>
    {
        public AddStoreroomRequestValidtor()
        {
            this.RuleFor(x => x.RoomNumber).InclusiveBetween(0, 10000);
            this.RuleFor(x => x.StoreroomName).Length(1, 250);
        }
    }
}
