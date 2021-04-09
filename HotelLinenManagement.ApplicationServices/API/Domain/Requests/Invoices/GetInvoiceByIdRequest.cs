using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices
{
    public class GetInvoiceByIdRequest : RequestBase, IRequest<GetInvoiceByIdResponse>
    {
        public int Id { get; set; }
    }
}
