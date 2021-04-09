using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Laundries;
using HotelLinenManagement.DataAccess.CQRS.Queries.Laundries;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteLaundryByIdHandler : IRequestHandler<DeleteLaundryByIdRequest, DeleteLaundryByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteLaundryByIdHandler(IMapper mapper,IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteLaundryByIdResponse> Handle(DeleteLaundryByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new DeleteLaundryByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            if (request.AuthenticationRole == "UserHotel")
            {
                return new DeleteLaundryByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetLaundryQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteLaundryByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var laundry = this.mapper.Map<Laundry>(request);
            var command = new DeleteLaundryByIdCommand()
            {
                Parameter = laundry
            };
            var laundryFromDb = await this.commandExecutor.Execute(command);

            return new DeleteLaundryByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Laundry>(laundryFromDb)
            };
        }
    }
}
