using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices
{
    public class GetAllInvoicesRequest : RequestBase, IRequest<GetAllInvoicesResponse>
    {
        public int? HotelId { get; set; }
        public int? LaundryId { get; set; }
    }
}
