﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class User :EntityBase
    {
      
        public List <Storeroom> Storerooms { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        public List<LiquidationDocument> LiquidationDocuments { get; set; }
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }
        public string Position { get; set; }
        [Required]
        [MaxLength(250)]
        public string Workplace { get; set; }
    }
}
