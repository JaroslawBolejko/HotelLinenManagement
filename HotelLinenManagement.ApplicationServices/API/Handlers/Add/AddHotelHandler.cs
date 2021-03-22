using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Hotels;
using HotelLinenManagement.DataAccess.CQRS.Queries.Hotels;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddHotelHandler : IRequestHandler<AddHotelRequest, AddHotelResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public AddHotelHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddHotelResponse> Handle(AddHotelRequest request, CancellationToken cancellationToken)
        {
            var query = new GetHotelsQuery()
            {
                TaxNumber = request.TaxNumber
            };
            var addNewResource = await queryExecutor.Execute(query);

            if (addNewResource != null)
            {
                return new AddHotelResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };

            }

            var hotel = this.mapper.Map<Hotel>(request);
            var command = new AddHotelCommand()
            {
                Parameter = hotel
            };
            var hotelfromDb = await this.commandExecutor.Execute(command);

            return new AddHotelResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Hotel>(hotelfromDb)
            };

        }
    }
}

