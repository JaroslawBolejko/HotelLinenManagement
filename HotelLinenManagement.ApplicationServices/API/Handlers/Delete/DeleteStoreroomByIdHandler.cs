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

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteStoreroomByIdHandler : IRequestHandler<DeleteStoreroomsByIdRequest, DeleteStoreroomsByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteStoreroomByIdHandler(IMapper mapper,IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteStoreroomsByIdResponse> Handle(DeleteStoreroomsByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStoreroomQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteStoreroomsByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var storeroom = this.mapper.Map<Storeroom>(request);
            var command = new DeleteStoreroomsByIdCommand()
            {
                Parameter = storeroom
            };
            var storeroomFromDb = await this.commandExecutor.Execute(command);

            return new DeleteStoreroomsByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Storeroom>(storeroomFromDb)
            };
        }
    }
}
