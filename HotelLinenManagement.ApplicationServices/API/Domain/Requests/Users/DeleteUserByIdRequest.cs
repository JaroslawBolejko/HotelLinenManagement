using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users
{
    public class DeleteUserByIdRequest : IRequest<DeleteUserByIdResponse>
    {
        public int Id { get; set; }
    }
}
