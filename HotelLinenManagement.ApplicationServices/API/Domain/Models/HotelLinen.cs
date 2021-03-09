using System.Collections.Generic;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class HotelLinen
    {
        public int Id { get; set; }
        public string LinenName { get; set; }
        public int LinenAmount { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public double LinienWeight { get; set; }
        public int StoreroomId { get; set; }

        //public DataAccess.Entities.Hotel Hotel { get; set; }
       // public DataAccess.Entities.Storeroom Storeroom { get; set; }
      
        //public List<DataAccess.Entities.Invoice> Invoices { get; set; }
        //public List<DataAccess.Entities.LinenType> LinienTypes { get; set; }
       // public List<DataAccess.Entities.GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        //public List<DataAccess.Entities.GoodsIssuedNote> GoodsIssuedNotes { get; set; }
      //  public List<DataAccess.Entities.LiquidationDocument> LiquidationDocuments { get; set; }
    }
}
