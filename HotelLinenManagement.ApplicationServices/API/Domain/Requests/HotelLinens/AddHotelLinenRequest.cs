using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class AddHotelLinenRequest : RequestBase, IRequest<AddHotelLinenResponse>
    {
        public string LinenName { get; set; }
        public int LinenAmount { get; set; }
        public string LinenTypeName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public double LinienWeight { get; set; }
        public int StoreroomId { get; set; }
        public int HotelId { get; set; }


    }
}
