using System;
using System.Collections.Generic;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class Laundry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public DateTime ReciptDate { get; set; }
        public DateTime IssueDate { get; set; }

        public List<DataAccess.Entities.Invoice> Invoices { get; set; }
        public List<DataAccess.Entities.HotelLinen> HotelLinens { get; set; }
        public List<DataAccess.Entities.GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<DataAccess.Entities.GoodsIssuedNote> GoodsIssuedNotes { get; set; }
    }
}

