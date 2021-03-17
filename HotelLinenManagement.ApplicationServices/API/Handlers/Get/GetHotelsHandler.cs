using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Hotels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetHotelsHandler : IRequestHandler<GetAllHotelsRequest, GetAllHotelsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetHotelsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllHotelsResponse> Handle(GetAllHotelsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetHotelsQuery()
            {
                HotelName = request.HotelName
            };
            var hotels = await this.queryExecutor.Execute(query);
            var mappedHotel = this.mapper.Map<List<Domain.Models.Hotel>>(hotels);

            var response = new GetAllHotelsResponse()
            {
                Data = mappedHotel
            };
            return response;
        }
    }
}
