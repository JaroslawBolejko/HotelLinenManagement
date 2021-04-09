using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices
{
    public class DeleteInvoiceByIdRequest : RequestBase, IRequest<DeleteInvoiceByIdResponse>
    {
        public int Id { get; set; }
    }
}
