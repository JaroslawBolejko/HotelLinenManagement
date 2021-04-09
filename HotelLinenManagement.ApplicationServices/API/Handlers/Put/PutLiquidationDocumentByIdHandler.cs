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

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutLiquidationDocumentByIdHandler : IRequestHandler<PutLiquidationDocumentByIdRequest, PutLiquidationDocumentByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public PutLiquidationDocumentByIdHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<PutLiquidationDocumentByIdResponse> Handle(PutLiquidationDocumentByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole != "AdminHotel")
            {
                return new PutLiquidationDocumentByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetLiquidationDocumentQuery()
            {
                Id = request.Id
            };

            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new PutLiquidationDocumentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var liquidationDoc = this.mapper.Map<LiquidationDocument>(request);
            var command = new PutLiquidationDocumentByIdCommand()
            {
                Parameter = liquidationDoc
            };
            var liquidationDocUpdated = await this.commandExecutor.Execute(command);

            return new PutLiquidationDocumentByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.LiquidationDocument>(liquidationDocUpdated)
            };
        }
    }
}
