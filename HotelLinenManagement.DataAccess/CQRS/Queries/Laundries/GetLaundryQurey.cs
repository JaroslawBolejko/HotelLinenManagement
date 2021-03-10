using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Laundries
{
    public class GetLaundryQuery : QueryBase<Laundry>
    {
        public int Id { get; set; }
        public override async Task<Laundry> Execute(HotelLinenWarehouseContext context)
        {
            return await context.Laundries.FirstOrDefaultAsync(x => x.Id == this.Id);
           
        }
    }
}
