﻿using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries
{
    public class GetAllLaundriesRequest : RequestBase, IRequest<GetAllLaundriesResponse>
    {
        public string TaxNumber { get; set; }

    }
}

