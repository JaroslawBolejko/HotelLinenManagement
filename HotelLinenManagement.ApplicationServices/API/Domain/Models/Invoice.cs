﻿using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class Invoice
    {
        public string DocumentName { get; set; }
 
        public int DocumentNumber { get; set; }

        public DateTime DocumentDate { get; set; }

        public string Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }
        public double InvoiceTotal { get; set; }

        public int HotelId { get; set; }
        public int LaundryId { get; set; }
       // public Hotel Hotel { get; set; }
      //  public Laundry Laundry { get; set; }

    }
}
