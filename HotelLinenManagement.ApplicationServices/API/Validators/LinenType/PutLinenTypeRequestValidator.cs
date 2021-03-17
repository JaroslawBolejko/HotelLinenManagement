using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;

namespace HotelLinenManagement.ApplicationServices.API.Validators.LinenType
{
    public class PutLinenTypeRequestValidator : AbstractValidator<PutLinenTypeByIdRequest>
    {
        public PutLinenTypeRequestValidator()
        {
            this.RuleFor(x => x.Id).NotNull().NotEmpty();
            this.RuleFor(x => x.LinenTypeName).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
