﻿using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels
{
    public class PutHotelByIdRequest : IRequest<PutHotelByIdResponse>
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
    }
}
