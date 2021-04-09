using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes
{
    public class DeleteLinenTypeByIdRequest : RequestBase, IRequest<DeleteLinenTypeByIdResponse>
    {
        public int Id { get; set; }
    }
}
