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

        public override async Task<List<Hotel>> Execute(HotelLinenWarehouseContext context)
        {

            if (!string.IsNullOrEmpty(this.HotelName))
            {
                return await context.Hotels.Where(x => x.HotelName.Contains(this.HotelName)).ToListAsync();
            }

            return await context.Hotels.ToListAsync();
        }
    }
}
