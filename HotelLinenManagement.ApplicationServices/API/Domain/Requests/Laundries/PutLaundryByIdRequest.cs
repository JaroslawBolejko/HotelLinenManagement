﻿using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries
{
    public class PutLaundryByIdRequest : RequestBase, IRequest<PutLaundryByIdResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public DateTime ReciptDate { get; set; }
        public DateTime IssueDate { get; set; }

    }
}
