using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users
{
    public class GetUserByIdRequest : RequestBase, IRequest<GetUserByIdResponse>
    {
        //public int? UserId { get; set; }
        public string Username { get; set; }

    }
}
