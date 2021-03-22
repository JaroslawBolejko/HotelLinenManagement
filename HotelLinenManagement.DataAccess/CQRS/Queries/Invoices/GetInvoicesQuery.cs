using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Invoices
{
    public class GetInvoicesQuery : QueryBase<List<Invoice>>
    {
        public int? HotelId { get; set; }
        public int? LaundryId { get; set; }
        public string DocumentName { get; set; }


        public override async Task<List<Invoice>> Execute(HotelLinenWarehouseContext context)
        {
            if (this.LaundryId != null && HotelId == null)
            {
                var result = await context.Invoices.Where(x => x.LaundryId == this.LaundryId).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }

            else if (this.LaundryId == null && HotelId != null)
            {
                var result = await context.Invoices.Where(x => x.HotelId == this.HotelId).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }

            else if (!string.IsNullOrEmpty(this.DocumentName))
            {

                if (context.Invoices.Any(x => x.DocumentName == this.DocumentName))
                    return null;

            }

            return await context.Invoices.ToListAsync();

        }
    }
}
