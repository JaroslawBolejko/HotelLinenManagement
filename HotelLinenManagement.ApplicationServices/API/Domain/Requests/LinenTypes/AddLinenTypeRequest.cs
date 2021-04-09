using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes
{
    public class AddLinenTypeRequest : RequestBase, IRequest<AddLinenTypeResponse>
    {
        public string LinenTypeName { get; set; }
    }
}
