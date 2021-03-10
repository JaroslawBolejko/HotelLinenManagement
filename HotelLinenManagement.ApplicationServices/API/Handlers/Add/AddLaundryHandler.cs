using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Laundries;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddLaundryHandler : IRequestHandler<AddLaundryRequest, AddLaundryResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddLaundryHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddLaundryResponse> Handle(AddLaundryRequest request, CancellationToken cancellationToken)
        {
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
