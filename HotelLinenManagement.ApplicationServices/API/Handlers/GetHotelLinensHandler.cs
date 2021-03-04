using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetHotelLinensHandler : IRequestHandler<GetAllHotelLinensRequest, GetAllHotelLinensResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetHotelLinensHandler(IMapper mapper,IQueryExecutor queryExecutor)
        {
          
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllHotelLinensResponse> Handle(GetAllHotelLinensRequest request, CancellationToken cancellationToken)
        {
            var query = new GetHotelLinensQuery();
            var hotelLinens = await this.queryExecutor.Execute(query);
            var mappedHotelLinen = this.mapper.Map<List<Domain.Models.HotelLinen>>(hotelLinens);
           

            var response = new GetAllHotelLinensResponse()
            {
                Data = mappedHotelLinen
            };
            return response;
        }
    }
}
