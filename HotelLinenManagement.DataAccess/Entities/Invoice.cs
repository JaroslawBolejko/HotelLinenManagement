using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        public HotelLinen HotelLinen{get;set;}
        [Required]
        public int InvoiceNumber { get; set; }
        [Required]
        public DateTime InviceDate { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal InvoiceTotal { get; set; }
    }
}
