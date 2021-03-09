using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutStoreroomsByIdHandler : IRequestHandler<PutStoreroomsByIdRequest, PutStoreroomsByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutStoreroomsByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutStoreroomsByIdResponse> Handle(PutStoreroomsByIdRequest request, CancellationToken cancellationToken)
        {
            var storeroom = this.mapper.Map<Storeroom>(request);
            var command = new PutStoreroomsByIdCommand()
            {
                Parameter = storeroom
            };
            var storeroomUpdated = await this.commandExecutor.Execute(command);

            return new PutStoreroomsByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Storeroom>(storeroomUpdated)
            };
        }
    }
}
