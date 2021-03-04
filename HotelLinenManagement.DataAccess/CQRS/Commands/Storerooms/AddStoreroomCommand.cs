using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Storerooms
{
    public class AddStoreroomCommand : CommandBase<Storeroom, Storeroom>
    {
        public override async Task<Storeroom> Execute(HotelLinenWarehouseContext context)
        {
            await context.Storerooms.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
