using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Hotels
{
    public class GetHotelQuery : QueryBase<Hotel>
    {
        public int Id { get; set; }
        public override async Task<Hotel> Execute(HotelLinenWarehouseContext context)
        {
            return await context.Hotels.FirstOrDefaultAsync(x => x.Id == this.Id);

        }
    }
}
