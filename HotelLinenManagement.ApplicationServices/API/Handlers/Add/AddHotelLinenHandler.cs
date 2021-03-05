using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddHotelLinenHandler : IRequestHandler<AddHotelLinenRequest, AddHotelLinenResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddHotelLinenHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddHotelLinenResponse> Handle(AddHotelLinenRequest request, CancellationToken cancellationToken)
        {
            var hotelLinen = this.mapper.Map<HotelLinen>(request);
            var command = new AddHotelLinenCommand() { Parameter = hotelLinen };
           var hotelLinenFromDb = await this.commandExecutor.Execute(command);
            return new AddHotelLinenResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.HotelLinen>(hotelLinenFromDb)
            };
        }
    }
}
