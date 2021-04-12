using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users;

namespace HotelLinenManagement.ApplicationServices.API.Validators.Users
{
    public class AddUserRequestValidtor : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidtor()
        {
            this.RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(250);
            this.RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(250);
            this.RuleFor(x => x.Position).NotNull().NotEmpty().MaximumLength(250);
            this.RuleFor(x => x.Workplace).NotNull().NotEmpty().MaximumLength(250);
          //  this.RuleFor(x => x.Permission).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
