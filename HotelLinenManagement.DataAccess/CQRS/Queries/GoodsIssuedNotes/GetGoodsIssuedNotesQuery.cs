using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.GoodsIssuedNotes
{
    public class GetGoodsIssuedNotesQuery : QueryBase<List<GoodsIssuedNote>>
    {
        public int? GoodsIssuedNoteNumber { get; set; }
        public override async Task<List<GoodsIssuedNote>> Execute(HotelLinenWarehouseContext context)
        {
            if (GoodsIssuedNoteNumber != null)
            {
                var result = await context.GoodsIssuedNotes.Where(x => x.DocumentNumber == this.GoodsIssuedNoteNumber).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            return await context.GoodsIssuedNotes.ToListAsync();
        }
    }
}


