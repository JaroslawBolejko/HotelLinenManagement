using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Users
{
    public class GetUserQuery : QueryBase<User>
    {
        public int Id { get; set; }
    
        public override async Task<User> Execute(HotelLinenWarehouseContext context)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
