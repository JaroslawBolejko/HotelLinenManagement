using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class Hotel : EntityBase 
    {
        [Required]
        [MaxLength(250)]
        public string HotelName { get; set; }
        [Required]
        [StringLength(12)]
        public string TaxNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string TelefonNumber { get; set; }
        
      //Tu trzeba jeszcze pouzupełniać

        public List<Storeroom> Storerooms { get; set; }
        public List<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        public List<LiquidationDocument> LiquidationDocuments { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }
        public List<Invoice> Invoices { get; set; }

    }
}
