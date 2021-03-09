using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.Users
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public string LastName { get; set; }
        public string Workplace { get; set; }

        public override async Task<List<User>> Execute(HotelLinenWarehouseContext context)
        {
            if (!string.IsNullOrEmpty(LastName))
            {
                return await context.Users.Where(x => x.LastName.Contains(this.LastName)).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(Workplace))
            {
                return await context.Users.Where(x => x.Workplace.Contains(this.Workplace)).ToListAsync();
            }
            return await context.Users.ToListAsync();

        }
    }
}
