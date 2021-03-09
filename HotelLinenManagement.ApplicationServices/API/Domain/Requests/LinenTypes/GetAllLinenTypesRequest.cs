using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests
{
    public class GetAllLinenTypesRequest : IRequest<GetAllLinenTypesResponse>
    {
        public string LinenTypeName { get; set; }

    }
}
