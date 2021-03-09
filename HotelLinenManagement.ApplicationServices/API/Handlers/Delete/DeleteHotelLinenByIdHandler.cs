using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.HotelLinens;
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
       
        private readonly ICommandExecutor commandExecutor;

        public DeleteHotelLinenByIdHandler(ICommandExecutor commandExecutor)
        {
           
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteHotelLinenByIdResponse> Handle(DeleteHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteHotelLinenByIdCommand()
            {
                Parameter = request.HotelLinenId
            };
            var deleteHotelLinen = await commandExecutor.Execute(command);
            return new DeleteHotelLinenByIdResponse
            {
                Data = deleteHotelLinen
            };
        }
    }
}
