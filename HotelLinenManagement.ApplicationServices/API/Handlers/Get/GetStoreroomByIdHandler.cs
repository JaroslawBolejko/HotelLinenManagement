using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Storerooms;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetStoreroomByIdHandler : IRequestHandler<GetStoreroomByIdRequest, GetStoreroomByIdResponse>
    {

        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetStoreroomByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetStoreroomByIdResponse> Handle(GetStoreroomByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStoreroomQuery()
            {
                Id = request.StoreroomId
            };
            var storerooms = await this.queryExecutor.Execute(query);
            if (storerooms == null)
            {
                return new GetStoreroomByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedStoreroom = this.mapper.Map<Domain.Models.Storeroom>(storerooms);

            var response = new GetStoreroomByIdResponse()
            {
                Data = mappedStoreroom
            };
            return response;
        }
    }
}
