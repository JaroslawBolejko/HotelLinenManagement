using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users
{
    public class GetMeRequest : RequestBase, IRequest<GetMeResponse>
    {
        public string Me { get; set; }

    }
}
