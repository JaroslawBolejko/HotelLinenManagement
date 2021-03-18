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

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutLaundryByIdHandler : IRequestHandler<PutLaundryByIdRequest, PutLaundryByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public PutLaundryByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<PutLaundryByIdResponse> Handle(PutLaundryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLaundryQuery()
            {
                Id = request.Id
            };

            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new PutLaundryByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var laundry = this.mapper.Map<Laundry>(request);
            var command = new PutLaundryByIdCommand()
            {
                Parameter = laundry
            };
            var laundryUpdated = await this.commandExecutor.Execute(command);

            return new PutLaundryByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Laundry>(laundryUpdated)
            };
        }
    }
}
