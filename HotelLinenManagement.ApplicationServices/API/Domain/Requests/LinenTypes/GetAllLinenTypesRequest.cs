using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes
{
    public class GetAllLinenTypesRequest : RequestBase, IRequest<GetAllLinenTypesResponse>
    {
        public string LinenTypeName { get; set; }

    }
}
