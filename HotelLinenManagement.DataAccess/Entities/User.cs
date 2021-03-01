using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.Entities
{
   public class User :EntityBase
    {
        public List <Storeroom> Storerooms { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        public List<LiquidationDocument> LiquidationDocuments { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}
