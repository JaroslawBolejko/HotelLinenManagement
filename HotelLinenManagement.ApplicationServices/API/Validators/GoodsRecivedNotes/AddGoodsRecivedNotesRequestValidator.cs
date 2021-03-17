using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;

namespace HotelLinenManagement.ApplicationServices.API.Validators.GoodsRecivedNotes
{
   public class AddGoodsRecivedNotesRequestValidator : AbstractValidator<AddGoodsReceivedNoteRequest>
    {
        public AddGoodsRecivedNotesRequestValidator()
        {

            this.RuleFor(x => x.GoodsReceivedNoteName).MaximumLength(100);
            this.RuleFor(x => x.GoodsReceivedNoteNumber).NotNull().NotEmpty();
            this.RuleFor(x => x.GoodsReceivedNoteDate).NotNull().NotEmpty();
        }
    }
}
