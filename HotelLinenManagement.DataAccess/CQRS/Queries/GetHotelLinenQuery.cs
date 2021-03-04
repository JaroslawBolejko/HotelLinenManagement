using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries
{
    public class GetHotelLinenQuery : QueryBase<HotelLinen>
    {
        public int Id { get; set; }
        public override async Task<HotelLinen> Execute(HotelLinenWarehouseContext context)
        {
            var hotelLinen = await context.HotelLinens.FirstOrDefaultAsync(x => x.Id == this.Id);
            return hotelLinen;
        }
    }
}
