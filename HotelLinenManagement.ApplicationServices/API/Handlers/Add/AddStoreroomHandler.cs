using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Storerooms;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddStoreroomHandler : IRequestHandler<AddStoreroomRequest, AddStoreroomResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddStoreroomHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddStoreroomResponse> Handle(AddStoreroomRequest request, CancellationToken cancellationToken)
        {
            var storeroom = this.mapper.Map<Storeroom>(request);
            var command = new AddStoreroomCommand() { Parameter = storeroom };
            var storeroomFromDb = await this.commandExecutor.Execute(command);
            return new AddStoreroomResponse()
            {
                Data = this.mapper.Map<Domain.Models.Storeroom>(storeroomFromDb)
            };

        }
    }
}
