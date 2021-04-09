using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users
{
   public class GetAllUsersRequest : RequestBase, IRequest<GetAllUsersResponse>
    {
        public string LastName { get; set; }
        public string Workplace { get; set; }
    }
}
