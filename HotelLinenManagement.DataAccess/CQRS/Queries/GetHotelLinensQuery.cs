using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries
{
    public class GetHotelLinensQuery : QueryBase<List<HotelLinen>>
    {
        public int Id { get; set; }

        public override Task<List<HotelLinen>> Execute(HotelLinenWarehouseContext context)
        {
            return context.HotelLinens.ToListAsync();
           
        }
    }
}
