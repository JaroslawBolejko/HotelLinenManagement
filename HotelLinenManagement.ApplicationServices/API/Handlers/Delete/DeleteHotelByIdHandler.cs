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

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteHotelByIdHandler : IRequestHandler<DeleteHotelByIdRequest, DeleteHotelByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteHotelByIdHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteHotelByIdResponse> Handle(DeleteHotelByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetHotelQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteHotelByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var hotel = this.mapper.Map<Hotel>(request);
            var command = new DeleteHotelByIdCommand()
            {
                Parameter = hotel
            };
            var hotelfromDb = await this.commandExecutor.Execute(command);

            return new DeleteHotelByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Hotel>(hotelfromDb)
            };
        }
    }
}
