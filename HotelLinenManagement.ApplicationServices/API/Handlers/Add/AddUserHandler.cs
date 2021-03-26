using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using HotelLinenManagement.ApplicationServices.Components.PassworHasher;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Users;
using HotelLinenManagement.DataAccess.CQRS.Queries.Users;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;
        private readonly IPasswordHasher passwordHasher;

        public AddUserHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IPasswordHasher passwordHasher)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
            this.passwordHasher = passwordHasher;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery()
            {
                //FirstName = request.FirstName,
                //LastName = request.LastName,
                //Position = request.Position,
                //Workplace = request.Workplace,
                //Permission = request.Permission,
                Username= request.Username,
                Password = request.Password

            };
            var userNotExist = await queryExecutor.Execute(query);

            if (userNotExist == null)
            {
                return new AddUserResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }
            var auth = passwordHasher.Hash(request.Password);
            request.Password = auth[0];
            request.Salt = auth[1];
            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand()
            {
                Parameter = user
            };
           
            var userformDb = await this.commandExecutor.Execute(command);

            return new AddUserResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.User>(userformDb)
            };

        }
    }
}
