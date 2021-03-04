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

        public override Task<List<HotelLinen>> Execute(HotelLinenWarehouseContext context)
        {
            //context.HotelLinens.ToListAsync();
            return context.HotelLinens.Where(x=>x.LinenName == this.LinenName).ToListAsync();
           
        }
    }
}
