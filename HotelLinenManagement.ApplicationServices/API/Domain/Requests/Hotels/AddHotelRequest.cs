using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels
{
    public class AddHotelRequest : IRequest<AddHotelResponse>
    {
        public string HotelName { get; set; }
    }
}
