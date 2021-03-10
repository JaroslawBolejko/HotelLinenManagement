using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests
{
    public class GetAllHotelsRequest : IRequest<GetAllHotelsResponse>
    {
        public string HotelName { get; set; }

    }
}
