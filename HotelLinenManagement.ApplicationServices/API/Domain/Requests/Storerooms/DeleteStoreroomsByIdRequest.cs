using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms
{
    public class DeleteStoreroomsByIdRequest : RequestBase, IRequest<DeleteStoreroomsByIdResponse>
    {
        public int Id { get; set; }
    }
}
