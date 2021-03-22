using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels
{
    public class GetAllHotelsRequest : IRequest<GetAllHotelsResponse>
    {
        public string HotelName { get; set; }
        public string TaxNumber { get; set; }


    }
}
