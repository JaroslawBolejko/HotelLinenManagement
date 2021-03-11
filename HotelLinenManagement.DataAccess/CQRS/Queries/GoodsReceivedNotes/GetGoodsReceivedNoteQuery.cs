using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.GoodsReceivedNotes
{
    public class GetGoodsReceivedNoteQuery : QueryBase<GoodsReceivedNote>
    {
        public int Id { get; set; }
        public override async Task<GoodsReceivedNote> Execute(HotelLinenWarehouseContext context)
        {
          return await context.GoodsReceivedNotes.FirstOrDefaultAsync(x => x.Id == this.Id);
            
        }
    }
}
