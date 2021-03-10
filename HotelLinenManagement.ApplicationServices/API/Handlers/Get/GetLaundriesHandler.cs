using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Laundries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetLaundriesHandler : IRequestHandler<GetAllLaundriesRequest, GetAllLaundriesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetLaundriesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllLaundriesResponse> Handle(GetAllLaundriesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLaundriesQuery()
            {
                TaxNumber = request.TaxNumber
            };
            var laundries = await this.queryExecutor.Execute(query);
            var mappedLaundry = this.mapper.Map<List<Domain.Models.Laundry>>(laundries);


            var response = new GetAllLaundriesResponse()
            {
                Data = mappedLaundry
            };
            return response;
        }
    }
}
