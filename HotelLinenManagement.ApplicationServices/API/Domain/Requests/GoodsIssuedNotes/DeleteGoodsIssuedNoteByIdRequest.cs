using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes
{
    public class DeleteGoodsIssuedNoteByIdRequest : IRequest<DeleteGoodsIssuedNoteByIdResponse>
    {
        public int Id { get; set; }
    }
}
