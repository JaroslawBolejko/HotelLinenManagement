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
        public string FirstName { get; set; }
        public string Position { get; set; }
        public string Permission { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }


        public override async Task<List<User>> Execute(HotelLinenWarehouseContext context)
        {
            if (!string.IsNullOrEmpty(this.LastName) && string.IsNullOrEmpty(this.Workplace))
            {
                var result = await context.Users.Where(x => x.LastName.Contains(this.LastName)).ToListAsync();
                if (result.Count == 0)
                    return null;
                else return result;
            }
            else if (string.IsNullOrEmpty(this.LastName) && !string.IsNullOrEmpty(this.Workplace))
            {
                var result = await context.Users.Where(x => x.Workplace.Contains(this.Workplace)).ToListAsync();
                if (result.Count == 0)
                    return null;
                else return result;
            }
            //Posprawdzać inne waunki!
            //else if (!string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Workplace))

            //{
            //    return await context.Users.Where(x=>x.LastName.Contains(this.LastName) && Workplace.
            //        Contains(this.Workplace)).ToListAsync();
            //}

            //  --->uzupełnić o username case<--
            //else if (!string.IsNullOrEmpty(this.Username))
            //{

            //    if (context.Users.Any(x => x.Username == this.Username))
            //        return null;

            //}

          //  return await context.Users.ToListAsync();


            else if (!string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName) && !string.IsNullOrEmpty(this.Position)
                && !string.IsNullOrEmpty(this.Workplace))
            {

                if (context.Users.Any(x => x.FirstName == this.FirstName && x.LastName == this.LastName
                   && x.Position == this.Position && x.Workplace == this.Workplace))
                    return null;
            }
            return await context.Users.ToListAsync();

        }
    }
}
