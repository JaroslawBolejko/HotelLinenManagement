using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens
{
    public class DeleteHotelLinenByIdCommand : CommandBase<int, int>
    {
        public override async Task<int> Execute(HotelLinenWarehouseContext context)
        {
            var entity = await context.HotelLinens.FindAsync(Parameter);
            context.HotelLinens.Remove(entity);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
