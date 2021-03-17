using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;

namespace HotelLinenManagement.ApplicationServices.API.Validators.GoodsIssuedNotes
{
    public class PutGoodsIssuedNoteRequestValidator : AbstractValidator<PutGoodsIssuedNoteByIdRequest>
    {
        public PutGoodsIssuedNoteRequestValidator()
        {
            this.RuleFor(x => x.Id).NotNull().NotEmpty();
            this.RuleFor(x => x.GoodsIssuedNoteName).MaximumLength(100);
            this.RuleFor(x => x.GoodsIssuedNoteNumber).NotNull().NotEmpty();
            this.RuleFor(x => x.GoodsIssuedNoteDate).NotNull().NotEmpty();
        }
    }
    
}
