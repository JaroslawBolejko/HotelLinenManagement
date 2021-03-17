using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;

namespace HotelLinenManagement.ApplicationServices.API.Validators.Laundries
{
    public class AddLaundryRequestValidator : AbstractValidator<AddLaundryRequest>
    {
        public AddLaundryRequestValidator()
        {
            this.RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(250);
            this.RuleFor(x => x.TaxNumber).NotNull().NotEmpty().Length(12);
            this.RuleFor(x => x.ReciptDate).NotNull().NotEmpty();
            this.RuleFor(x => x.IssueDate).NotNull().NotEmpty();
        }
    }
}


