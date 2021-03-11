using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.GoodsReceivedNotes
{
    public class AddGoodsReceivedNoteCommand : CommandBase<GoodsReceivedNote, GoodsReceivedNote>
    {
        public override async Task<GoodsReceivedNote> Execute(HotelLinenWarehouseContext context)
        {
            await context.GoodsReceivedNotes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}