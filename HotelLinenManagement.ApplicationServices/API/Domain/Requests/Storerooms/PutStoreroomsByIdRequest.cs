using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms
{
    public class PutStoreroomsByIdRequest : IRequest<PutStoreroomsByIdResponse>
    {
        public string Id { get; set; }
        public int RoomNumber { get; set; }
        public string StoreroomName { get; set; }
    }
}
