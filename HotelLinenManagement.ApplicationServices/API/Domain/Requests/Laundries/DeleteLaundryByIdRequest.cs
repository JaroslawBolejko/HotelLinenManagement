using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries
{
    public class DeleteLaundryByIdRequest : RequestBase, IRequest<DeleteLaundryByIdResponse>
    {
        public int Id { get; set; }
    }
}
