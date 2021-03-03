using System.Collections.Generic;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
     
        public List<Storeroom> Storerooms { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }
    }
}
