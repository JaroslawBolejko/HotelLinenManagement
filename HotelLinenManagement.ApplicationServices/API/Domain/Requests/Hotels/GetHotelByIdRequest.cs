using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels
{
    public class GetHotelByIdRequest : RequestBase, IRequest<GetHotelByIdResponse>
    {
        public int Id { get; set; }
    }
}
