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
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteHotelLinenByIdHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteHotelLinenByIdResponse> Handle(DeleteHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new DeleteHotelLinenByIdResponse
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
                return new DeleteHotelLinenByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
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
