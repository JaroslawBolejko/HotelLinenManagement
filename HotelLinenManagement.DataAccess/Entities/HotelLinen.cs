using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class HotelLinen : EntityBase
    {

        public Hotel Hotel { get; set; }
        [Required]
        public int StoreroomId{get;set;}
        public Storeroom Storeroom { get; set; }
       
        public List<Invoice> Invoices { get; set; }
        public List<LinenType> LinienTypes { get; set; }
        public List<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        public List<LiquidationDocument> LiquidationDocuments { get; set; }
        public List<Laundry> Laundries { get; set; }

        [Required]
        [MaxLength(250)]
        public string LinenName { get; set; }
        
        [Required]
        public int LinenAmount { get; set; }
        [MaxLength(250)]
        public string LinenTypeName { get; set; }
        [MaxLength(250)]
        public string Size { get; set; }
        [MaxLength(250)]
        public string Color { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public double LinienWeight { get; set; }

    }
}
