using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using MediatR;

namespace HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments
{
    public class DeleteLiquidationDocumentByIdRequest : IRequest<DeleteLiquidationDocumentByIdResponse>
    {
        public int Id { get; set; }
    }
}
