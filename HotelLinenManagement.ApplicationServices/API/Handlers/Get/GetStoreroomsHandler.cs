using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Storerooms;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetStoreroomsHandler : IRequestHandler<GetAllStoreroomsRequest, GetAllStoreroomsResponse>
    {
        
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetStoreroomsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
           
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllStoreroomsResponse> Handle(GetAllStoreroomsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStoreroomsQuery()
            {
                StoreroomName = request.StoreroomName
            };
            var storerooms = await this.queryExecutor.Execute(query);
           
            if (storerooms == null)
            {
                return new GetAllStoreroomsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedStoreroom = this.mapper.Map<List<Domain.Models.Storeroom>>(storerooms);

            var response = new GetAllStoreroomsResponse()
            {
                Data = mappedStoreroom
            };
            return response;
        }
    }
}
