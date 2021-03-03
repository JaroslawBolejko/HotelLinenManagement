using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class GoodsReceivedNote
    {
        public string Id { get; set; }
        public string GoodsReceivedNoteName { get; set; }

        public int GoodsReceivedNoteNumber { get; set; }

        public DateTime GoodsReceivedNoteDate { get; set; }
        public HotelLinen HotelLinen { get; set; }
        public User User { get; set; }
        public Hotel Hotel { get; set; }

    }
}
