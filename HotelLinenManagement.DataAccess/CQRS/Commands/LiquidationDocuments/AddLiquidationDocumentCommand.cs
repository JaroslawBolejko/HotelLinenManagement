using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.LiquidationDocuments
{
    public class AddLiquidationDocumentCommand : CommandBase<LiquidationDocument, LiquidationDocument>
    {
        public override async Task<LiquidationDocument> Execute(HotelLinenWarehouseContext context)
        {
            await context.LiquidationDocuments.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
