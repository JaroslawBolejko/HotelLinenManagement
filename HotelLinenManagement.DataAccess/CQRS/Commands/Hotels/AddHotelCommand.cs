using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Hotels
{
    public class AddHotelCommand : CommandBase<Hotel, Hotel>
    {
        public override async Task<Hotel> Execute(HotelLinenWarehouseContext context)
        {
            await context.Hotels.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
