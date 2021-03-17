using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;

namespace HotelLinenManagement.ApplicationServices.API.Validators.Users
{
    public class AddLiquidationDocumentRequestValidtor : AbstractValidator<AddLiquidationDocumentRequest>
    {
        public AddLiquidationDocumentRequestValidtor()
        {
            this.RuleFor(x => x.LiquidationDocName).NotNull().NotEmpty().MaximumLength(100);
            this.RuleFor(x => x.LiquidationDocNumber).NotNull().NotEmpty();
            this.RuleFor(x => x.LiquidationDocDate).NotNull().NotEmpty();

        }
    }
}
