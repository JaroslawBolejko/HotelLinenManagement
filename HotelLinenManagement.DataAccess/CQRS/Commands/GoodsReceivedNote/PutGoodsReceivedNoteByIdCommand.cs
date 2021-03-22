using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.GoodsReceivedNotes
{
    public class PutGoodsReceivedNoteByIdCommand : CommandBase<GoodsReceivedNote, GoodsReceivedNote>
    {
        public override async Task<GoodsReceivedNote> Execute(HotelLinenWarehouseContext context)
        {
            context.ChangeTracker.Clear();
            context.GoodsReceivedNotes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
