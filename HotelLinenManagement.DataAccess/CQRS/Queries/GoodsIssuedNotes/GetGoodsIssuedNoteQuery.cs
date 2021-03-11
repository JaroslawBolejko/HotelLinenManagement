using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.GoodsIssuedNotes
{
    public class GetGoodsIssuedNoteQuery : QueryBase<GoodsIssuedNote>
    {
        public int Id { get; set; }
        public override async Task<GoodsIssuedNote> Execute(HotelLinenWarehouseContext context)
        {
            return await context.GoodsIssuedNotes.FirstOrDefaultAsync(x => x.Id == this.Id);

        }
    }
}
