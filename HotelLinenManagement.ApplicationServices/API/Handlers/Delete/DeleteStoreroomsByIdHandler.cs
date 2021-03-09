using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Storerooms;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteStoreroomsByIdHandler : IRequestHandler<DeleteStoreroomsByIdRequest, DeleteStoreroomsByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteStoreroomsByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteStoreroomsByIdResponse> Handle(DeleteStoreroomsByIdRequest request, CancellationToken cancellationToken)
        {
            var storeroom = this.mapper.Map<Storeroom>(request);
            var command = new DeleteStoreroomsByIdCommand()
            {
                Parameter = storeroom
            };
            var storeroomFromDb = await this.commandExecutor.Execute(command);

            return new DeleteStoreroomsByIdResponse()
            {
                Data = this.mapper.Map < API.Domain.Models.Storeroom>(storeroomFromDb)
            };
        }
    }
}
