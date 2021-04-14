using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagement.DataAccess.CQRS.Queries.HotelLinens;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutHotelLinensByIdHandler : IRequestHandler<PutHotelLinensByIdRequest, PutHotelLinensByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public PutHotelLinensByIdHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<PutHotelLinensByIdResponse> Handle(PutHotelLinensByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new PutHotelLinensByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            var query = new GetHotelLinenQuery()
            {
                Id = request.Id
            };

            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new PutHotelLinensByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var hotelLinen = this.mapper.Map<HotelLinen>(request);
            var command = new PutHotelLinensCommand()
            {
                Parameter = hotelLinen
            };
            var hotelLinenUpdated = await this.commandExecutor.Execute(command);

            return new PutHotelLinensByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.HotelLinen>(hotelLinenUpdated)
            };
        }
    }
}
