using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.GoodsIssuedNotes
{
    public class DeleteGoodsIssuedNoteByIdCommand : CommandBase<GoodsIssuedNote, GoodsIssuedNote>
    {
        public override async Task<GoodsIssuedNote> Execute(HotelLinenWarehouseContext context)
        {
            context.ChangeTracker.Clear();
            context.GoodsIssuedNotes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
