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
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddHotelLinenHandler : IRequestHandler<AddHotelLinenRequest, AddHotelLinenResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public AddHotelLinenHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<AddHotelLinenResponse> Handle(AddHotelLinenRequest request, CancellationToken cancellationToken)
        {
            //Tu chyba nie będę potrzebować sprawdzać konfliktu..
            //var query = new GetHotelLinensQuery()
            //{
            //};
            //var addNewResource = await queryExecutor.Execute(query);

            //if (addNewResource == null)
            //{
            //    return new AddHotelLinenResponse()
            //    {
            //        Error = new ErrorModel(ErrorType.Conflict)
            //    };
            //}
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
