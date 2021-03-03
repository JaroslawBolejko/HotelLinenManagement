using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class Hotel : EntityBase 
    {
        [Required]
        [MaxLength(250)]
        public string HotelName { get; set; }

        public List<Storeroom> Storerooms { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        public List<LiquidationDocument> LiquidationDocuments { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }

    }
}
