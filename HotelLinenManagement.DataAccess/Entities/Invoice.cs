using System;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class Invoice : DocumentBase
    {
        public Laundry Laundry { get; set; }
       
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal InvoiceTotal { get; set; }
    }
}
