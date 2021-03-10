using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.LinenTypes
{
    public class GetLinenTypeQuery : QueryBase<LinenType>
    {
        public int Id { get; set; }
        public override async Task<LinenType> Execute(HotelLinenWarehouseContext context)
        {
            return  await context.LinenTypes.FirstOrDefaultAsync(x => x.Id == this.Id);
            
        }
    }
}
