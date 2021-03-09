using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using MediatR;
using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments
{
    public class AddLiquidationDocumentRequest :IRequest<AddLiquidationDocumentResponse>
    {
        public string LiquidationDocName { get; set; }
        public int LiquidationDocNumber { get; set; }
        public DateTime LiquidationDocDate { get; set; }
    }
}
