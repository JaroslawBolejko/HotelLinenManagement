using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Storerooms;
using HotelLinenManagement.DataAccess.CQRS.Queries.Storerooms;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutStoreroomsByIdHandler : IRequestHandler<PutStoreroomsByIdRequest, PutStoreroomsByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public PutStoreroomsByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<PutStoreroomsByIdResponse> Handle(PutStoreroomsByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry" || request.AuthenticationRole == "UserHotel")
            {
                return new PutStoreroomsByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            var query = new GetStoreroomQuery()
            {
                Id = request.Id
            };

            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new PutStoreroomsByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var storeroom = this.mapper.Map<Storeroom>(request);
            var command = new PutStoreroomsByIdCommand()
            {
                Parameter = storeroom
            };
            var storeroomUpdated = await this.commandExecutor.Execute(command);

            return new PutStoreroomsByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Storeroom>(storeroomUpdated)
            };
        }
    }
}
