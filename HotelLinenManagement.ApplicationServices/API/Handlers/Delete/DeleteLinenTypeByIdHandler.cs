using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.LinenTypes;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteLinenTypeByIdHandler : IRequestHandler<DeleteLinenTypeByIdRequest, DeleteLinenTypeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteLinenTypeByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteLinenTypeByIdResponse> Handle(DeleteLinenTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var linenType = this.mapper.Map<LinenType>(request);
            var command = new DeleteLinenTypeByIdCommand()
            {
                Parameter = linenType
            };
            var linenTypeFromDb = await this.commandExecutor.Execute(command);

            return new DeleteLinenTypeByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.LinenType>(linenTypeFromDb)
            };
        }
    }
}
