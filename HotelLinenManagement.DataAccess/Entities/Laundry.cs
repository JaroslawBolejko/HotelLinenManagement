using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class Laundry : EntityBase
    {
        public List<Invoice> Invoices { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }
        public List<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string TaxNumber { get; set; }
        [Required]
        public DateTime ReciptDate { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }

    }
}
