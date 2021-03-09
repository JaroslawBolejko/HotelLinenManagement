using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class DeleteHotelLinenByIdRequest : IRequest<DeleteHotelLinenByIdResponse>
    {
        public int HotelLinenId { get; set; }
    }
}
