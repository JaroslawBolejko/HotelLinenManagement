using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels
{
    public class DeleteHotelByIdRequest : IRequest<DeleteHotelByIdResponse>
    {
        public int Id { get; set; }
    }
}
