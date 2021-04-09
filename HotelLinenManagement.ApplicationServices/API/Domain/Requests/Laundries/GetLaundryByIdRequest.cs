using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries
{
    public class GetLaundryByIdRequest : RequestBase, IRequest<GetLaundryByIdResponse>
    {
        public int Id { get; set; }
    }
}
