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
                var result = await context.Laundries.Where(x => x.TaxNumber.Contains(this.TaxNumber)).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
//toak samo jak przy Liqidation Document konflikt
            return await context.Laundries.ToListAsync();
        }
    }
}
