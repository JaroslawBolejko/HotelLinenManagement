using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class Storeroom : EntityBase
    {
        public List<HotelLinen> HotelLinens { get; set; }
        public Hotel Hotel { get; set; }
        public List<Invoice> Invices { get; set; }
        public List<LinenType> LinenTypes { get; set; }
        public List<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        public List<LiquidationDocument> LiquidationDocuments { get; set; }
        public List<User> Users { get; set; }

        [Required]
        public int RoomNumber { get; set; }
        [MaxLength(250)]
        
        public string StoreroomName { get; set; }
        [MaxLength(250)]
        
        [Required]
        public DateTime ReciptDate { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }

    }
}
