using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class GetHotelLinenByIdRequest : IRequest<GetHotelLinenByIdResponse>
    {
        public int HotelLinenId { get; set; }
    }
}
