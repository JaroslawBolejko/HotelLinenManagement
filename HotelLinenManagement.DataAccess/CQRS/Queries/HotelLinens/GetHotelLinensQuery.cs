using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.HotelLinens
{
    public class GetHotelLinensQuery : QueryBase<List<HotelLinen>>
    {
        public string LinenName { get; set; }
        public int? StoreroomId { get; set; }

        public override async Task<List<HotelLinen>> Execute(HotelLinenWarehouseContext context)
        {

            if (!string.IsNullOrEmpty(LinenName))
            {
                return await context.HotelLinens.Where(x => x.LinenName.Contains(this.LinenName)).ToListAsync();
            }

            else if (StoreroomId != null)
            {
                return await context.HotelLinens.Where(x => x.StoreroomId == this.StoreroomId).ToListAsync();
            }
            
            return await context.HotelLinens.ToListAsync();
           
        }
    }
}
