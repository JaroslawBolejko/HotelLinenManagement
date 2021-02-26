using System;
using System.Collections.Generic;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class Storeroom
    {
        public int RoomNumber { get; set; }
        public string StoreRoomName { get; set; }
        public DateTime ReciptDate { get; set; }
        public DateTime IssueDate { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }

    }
}
