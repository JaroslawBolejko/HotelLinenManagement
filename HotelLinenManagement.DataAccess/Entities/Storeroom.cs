﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class Storeroom : EntityBase
    {
        public List<HotelLinen> HotelLinens { get; set; }
        public Hotel Hotel { get; set; }
        

        [Required]
        public int RoomNumber { get; set; }
        [MaxLength(250)]
        
        public string StoreRoomName { get; set; }
        [MaxLength(250)]
        
        [Required]
        public DateTime ReciptDate { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }

    }
}
