using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Storerooms
{
    public class GetStoreroomsQuery : QueryBase<List<Storeroom>>
    {
        public string StoreroomName { get; set; }
        public int? RoomNumber { get; set; }

        public override async Task<List<Storeroom>> Execute(HotelLinenWarehouseContext context)
        {

            if (!string.IsNullOrEmpty(this.StoreroomName))
            {
                var result = await context.Storerooms.Include(x => x.HotelLinens).Where(x => x.StoreroomName
                .Contains(this.StoreroomName)).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
           else if (this.RoomNumber!=null)
            {

                if (context.Storerooms.Any(x => x.RoomNumber == this.RoomNumber))
                    return null;

            }

            return await context.Storerooms.Include(x => x.HotelLinens).ToListAsync();

        }
    }
}
