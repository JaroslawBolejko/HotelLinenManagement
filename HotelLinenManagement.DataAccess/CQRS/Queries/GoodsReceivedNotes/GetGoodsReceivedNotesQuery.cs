﻿using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.GoodsReceivedNotes
{
    public class GetGoodsReceivedNotesQuery : QueryBase<List<GoodsReceivedNote>>
    {
        public int? GoodsReceivedNoteNumber { get; set; }
        public override async Task<List<GoodsReceivedNote>> Execute(HotelLinenWarehouseContext context)
        {

            if (GoodsReceivedNoteNumber != null)
            {
                var result = await context.GoodsReceivedNotes.Where(x => x.DocumentNumber == this.GoodsReceivedNoteNumber).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }

            return await context.GoodsReceivedNotes.ToListAsync();

        }
    }
}
