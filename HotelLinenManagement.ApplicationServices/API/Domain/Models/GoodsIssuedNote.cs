using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class GoodsIssuedNote
    {
        public string Id { get; set; }
        public string GINName { get; set; }

        public int GINNumber { get; set; }

        public DateTime GINDate { get; set; }

    }
}
