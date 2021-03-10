using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Invoices
{
    public class GetInvoicesQuery : QueryBase<List<Invoice>>
    {
       // public int? HotelId { get; set; }
        public int? LaundryId { get; set; }

        public override async Task<List<Invoice>> Execute(HotelLinenWarehouseContext context)
        {
            if (LaundryId != null)
            {
                return await context.Invoices.Where(x => x.LaundryId == this.LaundryId).ToListAsync();
            }

            //else if (HotelId != null)
            //{
            //    return await context.Invoices.Where(x => x.HotelId == this.HotelId).ToListAsync();
            //}

            return await context.Invoices.ToListAsync();

        }
    }
}
