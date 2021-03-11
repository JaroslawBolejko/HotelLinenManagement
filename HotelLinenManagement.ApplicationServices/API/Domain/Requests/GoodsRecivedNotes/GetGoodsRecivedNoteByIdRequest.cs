using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes
{
    public class GetGoodsReceivedNoteByIdRequest : IRequest<GetGoodsReceivedNoteByIdResponse>
    {
        public int Id { get; set; }
    }
}
