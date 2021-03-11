using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class GoodsIssuedNote
    {
        public string Id { get; set; }
        public string GoodsIssuedNoteName { get; set; }

        public int GoodsIssuedNoteNumber { get; set; }

        public DateTime GoodsIssuedNoteDate { get; set; }
       // public HotelLinen HotelLinen { get; set; }
       // public User User { get; set; }
      //  public Hotel Hotel { get; set; }

    }
}
