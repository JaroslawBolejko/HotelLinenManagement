using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Storerooms
{
    public class DeleteStoreroomsByIdCommand : CommandBase<Storeroom, Storeroom>
    {
        public override async Task<Storeroom> Execute(HotelLinenWarehouseContext context)
        {
            context.Storerooms.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
