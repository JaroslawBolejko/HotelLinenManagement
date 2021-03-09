using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class PutHotelLinensByIdRequest : IRequest<PutHotelLinensByIdResponse>
    {
        public int Id { get; set; }
        public string LinenName { get; set; }
        public int LinenAmount { get; set; }
        public int StoreroomId { get; set; }
    }
}
