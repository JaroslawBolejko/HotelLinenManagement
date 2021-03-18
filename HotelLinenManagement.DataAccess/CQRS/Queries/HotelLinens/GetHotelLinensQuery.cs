using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries.HotelLinens
{
    public class GetHotelLinensQuery : QueryBase<List<HotelLinen>>
    {
        public string LinenName { get; set; }
        public int? StoreroomId { get; set; }

        public override async Task<List<HotelLinen>> Execute(HotelLinenWarehouseContext context)
        {

            if (!string.IsNullOrEmpty(LinenName) && StoreroomId == null)
            {
                var result = await context.HotelLinens.Where(x => x.LinenName.Contains(this.LinenName)).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }

            else if (string.IsNullOrEmpty(LinenName) && StoreroomId != null)
            {
                var result = await context.HotelLinens.Where(x => x.StoreroomId == this.StoreroomId).ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            //Dopisać warunek co mabyć podam oba, We wszystkich Query gdzie jest taka potrzeba?
            return await context.HotelLinens.ToListAsync();
           
        }
    }
}
