using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users
{
    public  class AddUserRequest : RequestBase, IRequest<AddUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Workplace { get; set; }
        public string Permission { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        
        public string Salt { get; set; }

    }
}
