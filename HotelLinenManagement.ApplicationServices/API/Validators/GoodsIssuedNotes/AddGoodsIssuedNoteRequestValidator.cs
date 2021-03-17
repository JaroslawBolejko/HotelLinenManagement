using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;

namespace HotelLinenManagement.ApplicationServices.API.Validators.GoodsIssuedNotes
{
    public class AddGoodsIssuedNoteRequestValidator : AbstractValidator<AddGoodsIssuedNoteRequest>
    {
        public AddGoodsIssuedNoteRequestValidator()
        {

            this.RuleFor(x => x.GoodsIssuedNoteName).MaximumLength(100);
            this.RuleFor(x => x.GoodsIssuedNoteNumber).NotNull().NotEmpty();
            this.RuleFor(x => x.GoodsIssuedNoteDate).NotNull().NotEmpty();
        }
    }
    
}
