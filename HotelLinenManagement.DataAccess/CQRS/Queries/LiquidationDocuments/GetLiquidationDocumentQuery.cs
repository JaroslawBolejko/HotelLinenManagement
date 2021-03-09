using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.LiquidationDocuments
{
    public class GetLiquidationDocumentQuery : QueryBase<LiquidationDocument>
    {
        public int Id { get; set; }
        public override async Task<LiquidationDocument> Execute(HotelLinenWarehouseContext context)
        {
            var liquidationDocument = await context.LiquidationDocuments.FirstOrDefaultAsync(x => x.Id == this.Id);
            return liquidationDocument;
        }
    }
}
