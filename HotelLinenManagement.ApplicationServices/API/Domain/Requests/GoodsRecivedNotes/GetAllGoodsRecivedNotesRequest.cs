using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes
{
    public class GetAllGoodsRecivedNotesRequest : IRequest<GetAllGoodsRecivedNotesResponse>
    {
        public int? GoodsReceivedNoteNumber { get; set; }

    }
}
