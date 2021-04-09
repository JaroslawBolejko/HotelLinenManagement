using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using MediatR;
using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes
{
    public class AddGoodsReceivedNoteRequest : RequestBase, IRequest<AddGoodsReceivedNoteResponse>
    {
        public string GoodsReceivedNoteName { get; set; }

        public int GoodsReceivedNoteNumber { get; set; }

        public DateTime GoodsReceivedNoteDate { get; set; }
    }
}
