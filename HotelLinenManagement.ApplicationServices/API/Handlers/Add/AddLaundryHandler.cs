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
    public class AddLaundryHandler : IRequestHandler<AddLaundryRequest, AddLaundryResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public AddLaundryHandler(IMapper mapper,IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddLaundryResponse> Handle(AddLaundryRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLaundriesQuery()
            {
                TaxNumber = request.TaxNumber
            };

            var addNewResource = await queryExecutor.Execute(query);

            if (addNewResource != null)
            {
                return new AddLaundryResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };

            }
            var laundry = this.mapper.Map<Laundry>(request);
            var command = new AddLaundryCommand()
            {
                Parameter = laundry
            };
            var laundryformDb = await this.commandExecutor.Execute(command);

            return new AddLaundryResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Laundry>(laundryformDb)
            };

        }
    }
}
