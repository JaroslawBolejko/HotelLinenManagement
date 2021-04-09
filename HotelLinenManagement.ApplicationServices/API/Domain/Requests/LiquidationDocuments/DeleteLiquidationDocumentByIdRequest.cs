using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments
{
    public class DeleteLiquidationDocumentByIdRequest : RequestBase, IRequest<DeleteLiquidationDocumentByIdResponse>
    {
        public int Id { get; set; }
    }
}
