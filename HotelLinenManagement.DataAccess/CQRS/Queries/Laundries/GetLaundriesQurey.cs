using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Laundries
{
    public class GetLaundriesQuery : QueryBase<List<Laundry>>
    {
        public string TaxNumber { get; set; }

        public override async Task<List<Laundry>> Execute(HotelLinenWarehouseContext context)
        {

            if (!string.IsNullOrEmpty(this.TaxNumber))
            {
                return await context.Laundries.Where(x => x.TaxNumber.Contains(this.TaxNumber)).ToListAsync();
            }

            return await context.Laundries.ToListAsync();
        }
    }
}
