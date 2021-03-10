using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.LinenTypes;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutLinenTypeByIdHandler : IRequestHandler<PutLinenTypeByIdRequest, PutLinenTypeByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutLinenTypeByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutLinenTypeByIdResponse> Handle(PutLinenTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var linenType = this.mapper.Map<LinenType>(request);
            var command = new PutLinenTypeByIdCommand()
            {
                Parameter = linenType
            };
            var linenTypeUpdated = await this.commandExecutor.Execute(command);

            return new PutLinenTypeByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.LinenType>(linenTypeUpdated)
            };
        }
    }
}
