using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using MediatR;
using System;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments
{
    public class PutLiquidationDocumentByIdRequest : RequestBase, IRequest<PutLiquidationDocumentByIdResponse>
    {
        public int Id { get; set; }
        public string LiquidationDocName { get; set; }
        public int LiquidationDocNumber { get; set; }
        public DateTime LiquidationDocDate { get; set; }
    }
}
