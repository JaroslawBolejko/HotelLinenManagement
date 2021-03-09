using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Storerooms;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddLiquidationDocumentHandler : IRequestHandler<AddLiquidationDocumentRequest, AddLiquidationDocumentResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddLiquidationDocumentHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddLiquidationDocumentResponse> Handle(AddLiquidationDocumentRequest request, CancellationToken cancellationToken)
        {
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
