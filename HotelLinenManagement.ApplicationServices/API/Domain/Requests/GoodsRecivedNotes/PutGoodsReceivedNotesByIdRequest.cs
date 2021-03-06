﻿using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using MediatR;
using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes
{
    public class PutGoodsReceivedNotesByIdRequest : RequestBase, IRequest<PutGoodsReceivedNotesByIdResponse>
    {
        public int Id { get; set; }
        public string GoodsReceivedNoteName { get; set; }
        public int GoodsReceivedNoteNumber { get; set; }
        public DateTime GoodsReceivedNoteDate { get; set; }
    }
}
