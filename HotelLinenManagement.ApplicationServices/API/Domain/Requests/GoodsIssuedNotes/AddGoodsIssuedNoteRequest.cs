using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using MediatR;
using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes
{
    public class AddGoodsIssuedNoteRequest : IRequest<AddGoodsIssuedNoteResponse>
    {
        public string GoodsIssuedNoteName { get; set; }

        public int GoodsIssuedNoteNumber { get; set; }

        public DateTime GoodsIssuedNoteDate { get; set; }
    }
}
