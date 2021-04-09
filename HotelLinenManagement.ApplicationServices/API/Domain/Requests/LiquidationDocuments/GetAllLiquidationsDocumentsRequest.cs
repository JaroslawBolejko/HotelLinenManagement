using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments
{
    public class GetAllLiquidationsDocumentsRequest : RequestBase, IRequest<GetAllLiquidationDocumentsResponse>
    {
        public int? LiquidationDocNumber { get; set; }

    }
}
