using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.HotelLinens
{
    public class GetStoreroomsQuery : QueryBase<List<Storeroom>>
    {
        public string StoreroomName { get; set; }

        public override async Task<List<Storeroom>> Execute(HotelLinenWarehouseContext context)
        {

            if (!string.IsNullOrEmpty(this.StoreroomName))
            {
                return await context.Storerooms.Where(x => x.StoreroomName.Contains(this.StoreroomName)).ToListAsync();
            }
            
            return await context.Storerooms.ToListAsync();

        }
    }
}
