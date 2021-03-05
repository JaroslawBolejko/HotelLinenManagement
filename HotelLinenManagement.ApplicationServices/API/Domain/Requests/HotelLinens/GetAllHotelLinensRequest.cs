﻿using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests
{
    public class GetAllHotelLinensRequest: IRequest<GetAllHotelLinensResponse>
    {
        public string LinenName { get; set; }
    }
}