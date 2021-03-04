using HotelLinenManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens
{
    public class AddHotelLinenCommand : CommandBase<HotelLinen, HotelLinen>
    {
        public override async Task<HotelLinen> Execute(HotelLinenWarehouseContext context)
        {
            await context.HotelLinens.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
