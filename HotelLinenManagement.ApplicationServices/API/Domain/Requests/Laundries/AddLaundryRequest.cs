using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using MediatR;
using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries
{
    public class AddLaundryRequest : IRequest<AddLaundryResponse>
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public DateTime ReciptDate { get; set; }
        public DateTime IssueDate { get; set; }
    }  
}
