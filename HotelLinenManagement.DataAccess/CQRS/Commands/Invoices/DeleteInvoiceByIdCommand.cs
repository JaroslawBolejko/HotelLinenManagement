using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Invoices
{
    public class DeleteInvoiceByIdCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(HotelLinenWarehouseContext context)
        {
            context.Invoices.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
