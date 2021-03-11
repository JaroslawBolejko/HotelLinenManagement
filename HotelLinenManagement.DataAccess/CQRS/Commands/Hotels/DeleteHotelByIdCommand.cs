using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Hotels
{
    public class DeleteHotelByIdCommand : CommandBase<Hotel, Hotel>
    {
        public override async Task<Hotel> Execute(HotelLinenWarehouseContext context)
        {
            context.Hotels.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
