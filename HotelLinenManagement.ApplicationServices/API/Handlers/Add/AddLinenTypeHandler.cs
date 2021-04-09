using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.LinenTypes;
using HotelLinenManagement.DataAccess.CQRS.Queries.LinenTypes;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddLinenTypeHandler : IRequestHandler<AddLinenTypeRequest, AddLinenTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public AddLinenTypeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddLinenTypeResponse> Handle(AddLinenTypeRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new AddLinenTypeResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetLinenTypesQuery()
            {
                LinenTypeName=request.LinenTypeName
            };
            var addNewResource = await queryExecutor.Execute(query);

            if (addNewResource != null)
            {
                return new AddLinenTypeResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }
            var linenType = this.mapper.Map<LinenType>(request);
                var command = new AddLinenTypeCommand()
                {
                    Parameter = linenType
                };
                var linenTypeformDb = await this.commandExecutor.Execute(command);

                return new AddLinenTypeResponse()
                {
                    Data = this.mapper.Map<API.Domain.Models.LinenType>(linenTypeformDb)
                };

            }
        }
    }
