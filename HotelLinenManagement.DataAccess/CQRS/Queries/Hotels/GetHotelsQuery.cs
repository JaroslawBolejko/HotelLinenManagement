using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Hotels
{
    public class GetHotelsQuery : QueryBase<List<Hotel>>
    {
        public string HotelName { get; set; }
        public string TaxNumber { get;set; }

        public override async Task<List<Hotel>> Execute(HotelLinenWarehouseContext context)
        {

            if (!string.IsNullOrEmpty(this.HotelName) && string.IsNullOrEmpty(this.TaxNumber))
            {
                var result = await context.Hotels.Where(x => x.HotelName.Contains(this.HotelName)).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            else if (string.IsNullOrEmpty(this.HotelName) && !string.IsNullOrEmpty(this.TaxNumber))
            {
                var result = await context.Hotels.Where(x => x.TaxNumber.Contains(this.TaxNumber)).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }

            return await context.Hotels.ToListAsync();
        }
    }
}
