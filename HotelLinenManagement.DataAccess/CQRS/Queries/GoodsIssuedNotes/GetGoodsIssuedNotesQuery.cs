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
                return await context.GoodsIssuedNotes.Where(x => x.DocumentNumber == this.GoodsIssuedNoteNumber).ToListAsync();
            }

            return await context.GoodsIssuedNotes.ToListAsync();

        }
    }
}


