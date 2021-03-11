using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.GoodsIssuedNotes
{
    public class AddGoodsIssuedNoteCommand : CommandBase<GoodsIssuedNote, GoodsIssuedNote>
    {
        public override async Task<GoodsIssuedNote> Execute(HotelLinenWarehouseContext context)
        {
            await context.GoodsIssuedNotes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}