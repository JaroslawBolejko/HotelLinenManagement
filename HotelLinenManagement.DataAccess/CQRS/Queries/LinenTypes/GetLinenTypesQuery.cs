using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.LinenTypes
{
    public class GetLinenTypesQuery : QueryBase<List<LinenType>>
    {
        public string LinenTypeName { get; set; }

        public override async Task<List<LinenType>> Execute(HotelLinenWarehouseContext context)
        {

            if (!string.IsNullOrEmpty(this.LinenTypeName))
            {
                var result = await context.LinenTypes.Where(x => x.LinenTypeName.Contains(this.LinenTypeName)).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            return await context.LinenTypes.ToListAsync();
        }
    }
}