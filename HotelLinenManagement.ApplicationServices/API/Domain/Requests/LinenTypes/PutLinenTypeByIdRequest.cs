﻿using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes
{
    public class PutLinenTypeByIdRequest : IRequest<PutLinenTypeByIdResponse>
    {
        public string Id { get; set; }
        public string LinenTypeName { get; set; }
    }
}
