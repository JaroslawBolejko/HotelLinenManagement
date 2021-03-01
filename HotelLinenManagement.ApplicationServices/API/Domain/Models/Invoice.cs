using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class Invoice
    {
        public string Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }
        public decimal InvoiceTotal { get; set; }
        public Hotel Hotel { get; set; }

    }
}
