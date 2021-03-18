using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.LinenTypes;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetLinenTypeByIdHandler : IRequestHandler<GetLinenTypeByIdRequest, GetLinenTypeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetLinenTypeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetLinenTypeByIdResponse> Handle(GetLinenTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLinenTypeQuery()
            {
                Id = request.Id
            };
            var linenType = await this.queryExecutor.Execute(query);

            if (linenType == null)
            {
                return new GetLinenTypeByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedLinenType = this.mapper.Map<Domain.Models.LinenType>(linenType);
            var response = new GetLinenTypeByIdResponse()
            {
                Data = mappedLinenType
            };
            return response;
        }
    }
}
