using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Users
{
    public class PutUserByIdCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(HotelLinenWarehouseContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
