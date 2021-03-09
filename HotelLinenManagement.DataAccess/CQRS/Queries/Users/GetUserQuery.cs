using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Users
{
    public class GetUserQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(HotelLinenWarehouseContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
            return user;
        }
    }
}
