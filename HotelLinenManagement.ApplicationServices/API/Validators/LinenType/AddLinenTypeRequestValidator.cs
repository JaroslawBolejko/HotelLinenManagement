using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;

namespace HotelLinenManagement.ApplicationServices.API.Validators.LinenType
{
    public class AddLinenTypeRequestValidator : AbstractValidator<AddLinenTypeRequest>
    {
        public AddLinenTypeRequestValidator()
        {
            this.RuleFor(x => x.LinenTypeName).NotNull().NotEmpty().Length(5,250);
        }
    }
}
