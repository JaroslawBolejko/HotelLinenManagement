using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes
{
    public class GetAllGoodsIssuedNotesRequest : RequestBase, IRequest<GetAllGoodsIssuedNotesResponse>
    {
        public int? GoodsIssuedNoteNumber { get; set; }

    }
}
