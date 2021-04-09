using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.LinenTypes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetLinenTypesHandler : IRequestHandler<GetAllLinenTypesRequest, GetAllLinenTypesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetLinenTypesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllLinenTypesResponse> Handle(GetAllLinenTypesRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new GetAllLinenTypesResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            var query = new GetLinenTypesQuery()
            {
                LinenTypeName = request.LinenTypeName
            };
            var linenTypes = await this.queryExecutor.Execute(query);


            if (linenTypes == null)
            {
                return new GetAllLinenTypesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedLinenType = this.mapper.Map<List<Domain.Models.LinenType>>(linenTypes);

            var response = new GetAllLinenTypesResponse()
            {
                Data = mappedLinenType
            };
            return response;
        }
    }
}
