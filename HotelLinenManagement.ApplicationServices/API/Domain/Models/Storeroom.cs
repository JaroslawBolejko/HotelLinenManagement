using System;
using System.Collections.Generic;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class Storeroom
    {
        public string Id { get; set; }
        public int RoomNumber { get; set; }
        public string StoreroomName { get; set; }
        public List<string> LinenName { get; set; }
        public List<int?> LinenAmount { get; set; }

        //public DateTime ReciptDate { get; set; }
        // public DateTime IssueDate { get; set; }
        //public List<HotelLinen> HotelLinens { get; set; }

    }
}
