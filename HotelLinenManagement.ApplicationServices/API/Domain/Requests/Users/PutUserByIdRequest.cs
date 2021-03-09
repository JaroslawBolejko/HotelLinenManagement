using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users
{
    public class PutUserByIdRequest : IRequest<PutUserByIdResponse>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Workplace { get; set; }

    }
}
