using HotelLinenManagement.ApplicationServices.API.Domain.Models;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices
{
    public class DeleteInvoiceByIdRequest : IRequest<DeleteInvoiceByIdResponse>
    {
        public int Id { get; set; }
    }
}
