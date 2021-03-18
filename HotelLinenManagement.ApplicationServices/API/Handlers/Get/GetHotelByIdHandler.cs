using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Hotels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetHotelByIdHandler : IRequestHandler<GetHotelByIdRequest, GetHotelByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetHotelByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetHotelByIdResponse> Handle(GetHotelByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetHotelQuery()
            {
                Id = request.Id
            };
            var hotel = await this.queryExecutor.Execute(query);

            if (hotel == null)
            {
                return new GetHotelByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedHotel = this.mapper.Map<Domain.Models.Hotel>(hotel);
            var response = new GetHotelByIdResponse()
            {
                Data = mappedHotel
            };
            return response;
        }
    }
}
