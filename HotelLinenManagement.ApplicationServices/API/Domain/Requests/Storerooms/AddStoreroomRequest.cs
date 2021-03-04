using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms
{
    public class AddStoreroomRequest : IRequest<AddStoreroomResponse>
    {
        public string StoreroomName{ get; set; }
    }
}
