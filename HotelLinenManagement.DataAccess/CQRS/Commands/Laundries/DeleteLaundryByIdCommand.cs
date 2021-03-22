using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Laundries
{
    public class DeleteLaundryByIdCommand : CommandBase<Laundry, Laundry>
    {
        public override async Task<Laundry> Execute(HotelLinenWarehouseContext context)
        {
            context.ChangeTracker.Clear();
            context.Laundries.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
