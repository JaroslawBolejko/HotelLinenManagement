using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Laundries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetLaundryByIdHandler : IRequestHandler<GetLaundryByIdRequest, GetLaundryByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetLaundryByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetLaundryByIdResponse> Handle(GetLaundryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLaundryQuery()
            {
                Id = request.Id
            };
            var laundry = await this.queryExecutor.Execute(query);

            if (laundry == null)
            {
                return new GetLaundryByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedLaundry = this.mapper.Map<Domain.Models.Laundry>(laundry);
            var response = new GetLaundryByIdResponse()
            {
                Data = mappedLaundry
            };
            return response;
        }
    }
}
