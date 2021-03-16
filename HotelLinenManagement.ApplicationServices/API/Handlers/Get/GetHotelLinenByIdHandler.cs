using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.HotelLinens;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetHotelLinenByIdHandler : IRequestHandler<GetHotelLinenByIdRequest, GetHotelLinenByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetHotelLinenByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetHotelLinenByIdResponse> Handle(GetHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetHotelLinenQuery()
            {
                Id = request.HotelLinenId
            };
            var hotelLinen = await this.queryExecutor.Execute(query);
            //Tu jest miejsce na sprawdzanie róznych akcji i obsługę tych errorów jakie mogą wysąpic
            if (hotelLinen == null)
            {
                return new GetHotelLinenByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedHotelLinen = this.mapper.Map<Domain.Models.HotelLinen>(hotelLinen);
            var response = new GetHotelLinenByIdResponse()
            {
                Data = mappedHotelLinen
            };
            return response;
        }
    }
}
