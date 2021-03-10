using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.LinenTypes
{
    public class AddLinenTypeCommand : CommandBase<LinenType, LinenType>
    {
        public override async Task<LinenType> Execute(HotelLinenWarehouseContext context)
        {
            await context.LinenTypes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
