using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Hotels
{
    public class PutHotelByIdCommand : CommandBase<Hotel, Hotel>
    {
        public override async Task<Hotel> Execute(HotelLinenWarehouseContext context)
        {
            context.ChangeTracker.Clear();
            context.Hotels.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
