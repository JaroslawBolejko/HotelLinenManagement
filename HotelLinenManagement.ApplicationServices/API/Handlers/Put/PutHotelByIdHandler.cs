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
    public class PutHotelByIdHandler : IRequestHandler<PutHotelByIdRequest, PutHotelByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public PutHotelByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<PutHotelByIdResponse> Handle(PutHotelByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole != "AdminHotel")
            {
                return new PutHotelByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            var query = new GetHotelQuery()
            {
                Id = request.Id
            };

            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new PutHotelByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var hotel = this.mapper.Map<Hotel>(request);
            var command = new PutHotelByIdCommand()
            {
                Parameter = hotel
            };
            var hotelUpdated = await this.commandExecutor.Execute(command);

            return new PutHotelByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Hotel>(hotelUpdated)
            };
        }
    }
}
