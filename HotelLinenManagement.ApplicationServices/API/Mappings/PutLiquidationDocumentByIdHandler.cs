using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutLiquidationDocumentByIdHandler : IRequestHandler<PutLiquidationDocumentByIdRequest, PutLiquidationDocumentByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutLiquidationDocumentByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutLiquidationDocumentByIdResponse> Handle(PutLiquidationDocumentByIdRequest request, CancellationToken cancellationToken)
        {
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
