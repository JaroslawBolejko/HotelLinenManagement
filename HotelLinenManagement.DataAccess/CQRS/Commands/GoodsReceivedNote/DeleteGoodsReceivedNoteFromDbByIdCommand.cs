using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.GoodsReceivedNotes
{
    public class DeleteGoodsReceivedNoteByIdCommand : CommandBase<GoodsReceivedNote, GoodsReceivedNote>
    {
        public override async Task<GoodsReceivedNote> Execute(HotelLinenWarehouseContext context)
        {
            context.GoodsReceivedNotes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
