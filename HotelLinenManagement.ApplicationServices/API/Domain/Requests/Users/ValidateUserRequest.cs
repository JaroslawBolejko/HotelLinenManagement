using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users
{
    public class ValidateUserRequest : IRequest<ValidateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
