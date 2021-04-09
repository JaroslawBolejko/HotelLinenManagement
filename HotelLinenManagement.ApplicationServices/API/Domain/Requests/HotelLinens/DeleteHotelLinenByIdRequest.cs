using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class DeleteHotelLinenByIdRequest : RequestBase, IRequest<DeleteHotelLinenByIdResponse>
    {
        public int Id { get; set; }
    }
}
