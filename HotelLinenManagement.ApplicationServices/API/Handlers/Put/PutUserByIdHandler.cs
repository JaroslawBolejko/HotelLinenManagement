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

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutUserByIdHandler : IRequestHandler<PutUserByIdRequest, PutUserByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public PutUserByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<PutUserByIdResponse> Handle(PutUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new PutUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
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
