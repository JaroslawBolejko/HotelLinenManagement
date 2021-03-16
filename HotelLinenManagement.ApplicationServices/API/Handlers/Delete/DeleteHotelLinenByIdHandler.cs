using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteHotelLinenByIdHandler : IRequestHandler<DeleteHotelLinenByIdRequest, DeleteHotelLinenByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteHotelLinenByIdHandler(IMapper mapper,ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteHotelLinenByIdResponse> Handle(DeleteHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {
            var hotelLinen = this.mapper.Map<HotelLinen>(request);
            var command = new DeleteHotelLinenByIdCommand()
            {
                Parameter = hotelLinen
            };
            var deleteHotelLinen = await commandExecutor.Execute(command);
            return new DeleteHotelLinenByIdResponse
            {
                Data = this.mapper.Map<API.Domain.Models.HotelLinen>(deleteHotelLinen)
            };
        }
    }
}
