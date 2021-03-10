using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Invoices
{
    public class GetInvoiceQuery : QueryBase<Invoice>
    {
        public int Id { get; set; }
        public override async Task<Invoice> Execute(HotelLinenWarehouseContext context)
        {
            return await context.Invoices.FirstOrDefaultAsync(x => x.Id == this.Id);

        }
    }
}
