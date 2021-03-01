using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class GoodsRecivedNote
    {
        public string Id { get; set; }
        public string GRNName { get; set; }

        public int GRNNumber { get; set; }

        public DateTime GRNDate { get; set; }

    }
}
