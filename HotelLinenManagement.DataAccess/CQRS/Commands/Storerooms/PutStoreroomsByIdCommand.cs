using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens
{
    public class PutStoreroomsByIdCommand : CommandBase<Storeroom, Storeroom>
    {
        public override async Task<Storeroom> Execute(HotelLinenWarehouseContext context)
        {
            context.Storerooms.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
