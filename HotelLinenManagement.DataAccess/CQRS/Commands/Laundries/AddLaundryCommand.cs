using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Laundries
{
    public class AddLaundryCommand : CommandBase<Laundry, Laundry>
    {
        public override async Task<Laundry> Execute(HotelLinenWarehouseContext context)
        {
            await context.Laundries.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
