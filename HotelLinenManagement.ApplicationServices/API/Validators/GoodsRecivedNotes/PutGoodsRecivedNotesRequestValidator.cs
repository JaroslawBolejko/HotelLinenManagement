using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;

namespace HotelLinenManagement.ApplicationServices.API.Validators.GoodsRecivedNotes
{
   public class PutGoodsRecivedNotesRequestValidator : AbstractValidator<PutGoodsReceivedNotesByIdRequest>
    {
        public PutGoodsRecivedNotesRequestValidator()
        {
            this.RuleFor(x => x.Id).NotNull().NotEmpty();
            this.RuleFor(x => x.GoodsReceivedNoteName).MaximumLength(20);
            this.RuleFor(x => x.GoodsReceivedNoteNumber).NotNull().NotEmpty();
            this.RuleFor(x => x.GoodsReceivedNoteDate).NotNull().NotEmpty();
        }
    }
}
