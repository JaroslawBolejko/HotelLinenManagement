using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Hotels;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutHotelByIdHandler : IRequestHandler<PutHotelByIdRequest, PutHotelByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutHotelByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutHotelByIdResponse> Handle(PutHotelByIdRequest request, CancellationToken cancellationToken)
        {
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
