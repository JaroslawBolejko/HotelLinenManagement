using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.LinenTypes
{
    public class PutLinenTypeByIdCommand : CommandBase<LinenType, LinenType>
    {
        public override async Task<LinenType> Execute(HotelLinenWarehouseContext context)
        {
            context.ChangeTracker.Clear();
            context.LinenTypes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
