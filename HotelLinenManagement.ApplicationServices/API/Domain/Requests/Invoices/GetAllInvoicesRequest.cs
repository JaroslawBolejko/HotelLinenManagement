using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests
{
    public class GetAllInvoicesRequest : IRequest<GetAllInvoicesResponse>
    {
        //public int? HotelId { get; set; }
        public int? LaundryId { get; set; }
    }
}
