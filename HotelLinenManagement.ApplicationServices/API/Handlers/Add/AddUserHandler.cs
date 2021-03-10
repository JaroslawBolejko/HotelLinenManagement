using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Storerooms;
using HotelLinenManagement.DataAccess.CQRS.Commands.Users;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand()
            {
                Parameter = user
            };
            var userformDb = await this.commandExecutor.Execute(command);

            return new AddUserResponse()
            {
                Data = this.mapper.Map < API.Domain.Models.User> (userformDb)
            };

        }
    }
}
