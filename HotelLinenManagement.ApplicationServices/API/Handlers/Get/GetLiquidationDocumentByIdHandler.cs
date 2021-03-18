using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.LiquidationDocuments;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Get
{
    public class GetLiquidationDocumentByIdHandler : IRequestHandler<GetLiquidationDocumentByIdRequest, GetLiquidationDocumentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetLiquidationDocumentByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetLiquidationDocumentByIdResponse> Handle(GetLiquidationDocumentByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLiquidationDocumentQuery()
            {
                Id = request.Id
            };

            var liquidationDoc = await this.queryExecutor.Execute(query);

            if (liquidationDoc == null)
            {
                return new GetLiquidationDocumentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mapppedLiquidationDoc = this.mapper.Map<Domain.Models.LiquidationDocument>(liquidationDoc);

            var response = new GetLiquidationDocumentByIdResponse()
            {
                Data = mapppedLiquidationDoc
            };
            return response;
            
        }
    }
}
