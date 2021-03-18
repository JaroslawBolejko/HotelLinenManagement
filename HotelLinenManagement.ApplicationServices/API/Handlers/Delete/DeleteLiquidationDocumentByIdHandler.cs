using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.LiquidationDocuments;
using HotelLinenManagement.DataAccess.CQRS.Queries.LiquidationDocuments;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteLiquidationDocumentByIdHandler : IRequestHandler<DeleteLiquidationDocumentByIdRequest, DeleteLiquidationDocumentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteLiquidationDocumentByIdHandler(IMapper mapper,IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteLiquidationDocumentByIdResponse> Handle(DeleteLiquidationDocumentByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLiquidationDocumentQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteLiquidationDocumentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
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
