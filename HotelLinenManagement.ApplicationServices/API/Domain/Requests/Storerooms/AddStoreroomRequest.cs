using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms
{
    public class AddStoreroomRequest : RequestBase, IRequest<AddStoreroomResponse>
    {
        public string StoreroomName{ get; set; }
        public int? RoomNumber { get; set; }
    }
}
