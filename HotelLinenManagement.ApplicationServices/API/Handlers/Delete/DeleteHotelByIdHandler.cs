using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Hotels;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteHotelByIdHandler : IRequestHandler<DeleteHotelByIdRequest, DeleteHotelByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteHotelByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteHotelByIdResponse> Handle(DeleteHotelByIdRequest request, CancellationToken cancellationToken)
        {
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
