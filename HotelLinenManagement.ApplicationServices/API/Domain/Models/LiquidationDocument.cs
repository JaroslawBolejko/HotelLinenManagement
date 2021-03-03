using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class LiquidationDocument
    {
        public string Id { get; set; }
        public string LiquidationDocName { get; set; }

        public int LiquidationDocNumber { get; set; }

        public DateTime LiquidationDocDate { get; set; }
        public HotelLinen HotelLinen { get; set; }
        public User User { get; set; }
        public Hotel Hotel { get; set; }

    }
}
