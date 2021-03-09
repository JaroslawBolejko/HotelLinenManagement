using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutUserByIdHandler : IRequestHandler<PutUserByIdRequest, PutUserByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutUserByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutUserByIdResponse> Handle(PutUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new PutUserByIdCommand()
            {
                Parameter = user
            };
            var userUpdated = await this.commandExecutor.Execute(command);

            return new PutUserByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.User>(userUpdated)
            };
        }
    }
}
