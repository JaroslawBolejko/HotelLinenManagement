using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests
{
    public class GetAllHotelLinensRequest : RequestBase, IRequest<GetAllHotelLinensResponse>
    {
        public int? StoreroomId { get; set; }
        public string LinenName { get; set; }
    }
}
