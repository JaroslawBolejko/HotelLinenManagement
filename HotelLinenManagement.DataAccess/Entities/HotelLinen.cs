using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class HotelLinen : EntityBase
    {
        //HotelId to wskaznie po czym ma się łączyć z z inna tabelą w relacji, jak nie określimy tego klucza
        //to entity zrobi to za nas

        public Hotel Hotel {get;set;}
        public List<Invoice> Invices { get; set; }
        public List<LinenType> LinienTypes { get; set; }
        public List<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        public List<LiquidationDocument> LiquidationDocuments { get; set; }

        [Required]
        [MaxLength(250)]
        public string LinenName { get; set; }
        
        [Required]
        public int LinenAmount { get; set; }
        [MaxLength(250)]
        public string Size { get; set; }
        [MaxLength(250)]
        public string Color { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public double LinienWeight { get; set; }

    }
}
