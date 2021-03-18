using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Users;
using HotelLinenManagement.DataAccess.CQRS.Queries.Users;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdRequest, DeleteUserByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteUserByIdHandler(IMapper mapper,IQueryExecutor queryExecutor, ICommandExecutor commandExecutor )
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteUserByIdResponse> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Id = request.UserId
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var user = this.mapper.Map<User>(request);
            var command = new DeleteUserByIdCommand()
            {
                Parameter = user
            };
            var userFromDB = await this.commandExecutor.Execute(command);

            return new DeleteUserByIdResponse()
            {
                Data = this.mapper.Map < API.Domain.Models.User> (userFromDB)
            };
        }
    }
}
