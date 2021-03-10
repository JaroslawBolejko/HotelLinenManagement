using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.LiquidationDocuments
{
    public class PutLiquidationDocumentByIdCommand : CommandBase<LiquidationDocument, LiquidationDocument>
    {
        public override async Task<LiquidationDocument> Execute(HotelLinenWarehouseContext context)
        {
            context.LiquidationDocuments.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
