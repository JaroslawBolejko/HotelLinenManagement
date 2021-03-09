using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms
{
    public  class GetStoreroomByIdRequest : IRequest<GetStoreroomByIdResponse>
    {
        public int StoreroomId { get; set; }
    }
}
