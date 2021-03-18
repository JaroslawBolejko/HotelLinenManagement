using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms
{
    public class PutStoreroomsByIdRequest : IRequest<PutStoreroomsByIdResponse>
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string StoreroomName { get; set; }
    }
}
