﻿using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.LiquidationDocuments
{
    public class DeleteLiquidationDocumentByIdCommand : CommandBase<LiquidationDocument, LiquidationDocument>
    {
        public override async Task<LiquidationDocument> Execute(HotelLinenWarehouseContext context)
        {
            context.ChangeTracker.Clear();
            context.LiquidationDocuments.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
