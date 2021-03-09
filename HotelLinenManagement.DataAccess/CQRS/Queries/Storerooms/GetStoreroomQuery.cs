using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.HotelLinens
{
    public class GetStoreroomQuery : QueryBase<Storeroom>
    {
        public int Id { get; set; }
        public override async Task<Storeroom> Execute(HotelLinenWarehouseContext context)
        {
            var storeroom = await context.Storerooms.FirstOrDefaultAsync(x => x.Id == this.Id);
            return storeroom;
        }
    }
}
