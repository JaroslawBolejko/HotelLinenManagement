using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class AddHotelLinenRequest : IRequest<AddHotelLinenResponse>
    {
        public string LinenName { get; set; }
    }
}
