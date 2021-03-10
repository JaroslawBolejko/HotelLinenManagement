﻿using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.LiquidationDocuments
{
    public class GetLiquidationDocumentsQuery : QueryBase<List<LiquidationDocument>>
    {
        public int? LiquidationDocNumber { get; set; }
        public override async Task<List<LiquidationDocument>> Execute(HotelLinenWarehouseContext context)
        {

           
            if (LiquidationDocNumber != null)
            {
                return await context.LiquidationDocuments.Where(x => x.DocumentNumber == this.LiquidationDocNumber).ToListAsync();
            }

            return await context.LiquidationDocuments.ToListAsync();

        }
    }
}