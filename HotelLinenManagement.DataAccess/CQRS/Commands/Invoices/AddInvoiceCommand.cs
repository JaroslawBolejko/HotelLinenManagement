using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Invoices
{
    public class AddInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(HotelLinenWarehouseContext context)
        {
            await context.Invoices.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
