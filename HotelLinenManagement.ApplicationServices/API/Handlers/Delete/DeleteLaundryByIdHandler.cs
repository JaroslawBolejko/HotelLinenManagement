using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Laundries;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteLaundryByIdHandler : IRequestHandler<DeleteLaundryByIdRequest, DeleteLaundryByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteLaundryByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteLaundryByIdResponse> Handle(DeleteLaundryByIdRequest request, CancellationToken cancellationToken)
        {
            var laundry = this.mapper.Map<Laundry>(request);
            var command = new DeleteLaundryByIdCommand()
            {
                Parameter = laundry
            };
            var laundryFromDb = await this.commandExecutor.Execute(command);

            return new DeleteLaundryByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Laundry>(laundryFromDb)
            };
        }
    }
}
