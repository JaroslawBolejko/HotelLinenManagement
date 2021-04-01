using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Users
{
    public class GetUserQuery : QueryBase<User>
    {
        public int? Id { get; set; }
        public string Username { get; set; }



        public override async Task<User> Execute(HotelLinenWarehouseContext context)
        {
            if(this.Id!=null  && string.IsNullOrEmpty(this.Username))
            return await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
            return await context.Users.FirstOrDefaultAsync(x => x.Username == this.Username);

        }
    }
}
