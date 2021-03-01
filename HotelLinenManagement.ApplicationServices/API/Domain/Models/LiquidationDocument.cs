using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class LiquidationDocument
    {
        public string Id { get; set; }
        public string LiquidationDocName { get; set; }

        public int LiquidationDocNumber { get; set; }

        public DateTime LiquidationDocDate { get; set; }


    }
}
