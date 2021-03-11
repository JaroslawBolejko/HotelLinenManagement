using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using MediatR;
using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices
{
    public class PutInvoiceByIdRequest : IRequest<PutInvoiceByIdResponse>
    {
        public string Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }
        public decimal InvoiceTotal { get; set; }
        public int HotelId { get; set; }
        public int LaundryId { get; set; }
        public string DocumentName { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
    }
}
