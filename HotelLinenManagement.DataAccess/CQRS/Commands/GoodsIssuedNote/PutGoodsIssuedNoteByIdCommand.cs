using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.GoodsIssuedNotes
{
    public class PutGoodsIssuedNoteByIdCommand : CommandBase<GoodsIssuedNote, GoodsIssuedNote>
    {
        public override async Task<GoodsIssuedNote> Execute(HotelLinenWarehouseContext context)
        {
            context.GoodsIssuedNotes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
