using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.LiquidationDocuments;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteLiquidationDocumentByIdHandler : IRequestHandler<DeleteLiquidationDocumentByIdRequest, DeleteLiquidationDocumentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteLiquidationDocumentByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteLiquidationDocumentByIdResponse> Handle(DeleteLiquidationDocumentByIdRequest request, CancellationToken cancellationToken)
        {
            var liquidationDoc = this.mapper.Map<LiquidationDocument>(request);
            var command = new DeleteLiquidationDocumentByIdCommand()
            {
                Parameter = liquidationDoc
            };
            var liquidationDocFromDb = await this.commandExecutor.Execute(command);

            return new DeleteLiquidationDocumentByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.LiquidationDocument>(liquidationDocFromDb)
            };
        }
    }
}
