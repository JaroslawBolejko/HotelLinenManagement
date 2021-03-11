using System;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        public int LaundryId { get; set; }
        public Laundry Laundry { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public DateTime DocumentDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal InvoiceTotal { get; set; }
        [Required]
        [MaxLength(250)]
        public string DocumentName { get; set; }
        [Required]
        public int DocumentNumber { get; set; }

    }
}
