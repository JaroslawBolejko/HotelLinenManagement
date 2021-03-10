using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes
{
    public class GetLinenTypeByIdRequest : IRequest<GetLinenTypeByIdResponse>
    {
        public int Id { get; set; }
    }
}
