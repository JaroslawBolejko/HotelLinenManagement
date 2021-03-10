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
    public class AddLinenTypeHandler : IRequestHandler<AddLinenTypeRequest, AddLinenTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddLinenTypeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddLinenTypeResponse> Handle(AddLinenTypeRequest request, CancellationToken cancellationToken)
        {
            var linenType = this.mapper.Map<LinenType>(request);
            var command = new AddLinenTypeCommand()
            {
                Parameter = linenType
            };
            var linenTypeformDb = await this.commandExecutor.Execute(command);

            return new AddLinenTypeResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.LinenType>(linenTypeformDb)
            };

        }
    }
}
