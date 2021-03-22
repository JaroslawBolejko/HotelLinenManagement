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
    public class AddLiquidationDocumentHandler : IRequestHandler<AddLiquidationDocumentRequest, AddLiquidationDocumentResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public AddLiquidationDocumentHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<AddLiquidationDocumentResponse> Handle(AddLiquidationDocumentRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLiquidationDocumentsQuery()
            {
                LiquidationDocNumber = request.LiquidationDocNumber

            };
            var addNewResource = await queryExecutor.Execute(query);
            
            if (addNewResource !=null)
            {
                return new AddLiquidationDocumentResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }
            var liquidationDoc = this.mapper.Map<LiquidationDocument>(request);
            var command = new AddLiquidationDocumentCommand() { Parameter = liquidationDoc };
            var liquidationDocFromDb = await this.commandExecutor.Execute(command);
            return new AddLiquidationDocumentResponse()
            {
                Data = this.mapper.Map<Domain.Models.LiquidationDocument>(liquidationDocFromDb)
            };

        }
    }
}
