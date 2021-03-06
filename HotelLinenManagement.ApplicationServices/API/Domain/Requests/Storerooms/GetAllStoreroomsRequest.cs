﻿using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using MediatR;
namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests
{
    public class GetAllStoreroomsRequest : RequestBase, IRequest<GetAllStoreroomsResponse>
    {
        public string StoreroomName { get; set; }
    }
}
