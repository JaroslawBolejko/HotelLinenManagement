using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.LinenTypes
{
    public class DeleteLinenTypeByIdCommand : CommandBase<LinenType, LinenType>
    {
        public override async Task<LinenType> Execute(HotelLinenWarehouseContext context)
        {
            context.ChangeTracker.Clear();
            context.LinenTypes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
