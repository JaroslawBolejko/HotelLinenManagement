using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.LiquidationDocuments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Get
{
    public class GetLiquidationDocumentsHandler : IRequestHandler<GetAllLiquidationsDocumentsRequest, GetAllLiquidationDocumentsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetLiquidationDocumentsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllLiquidationDocumentsResponse> Handle(GetAllLiquidationsDocumentsRequest request, CancellationToken cancellationToken)
        {
            //if (request.AuthenticationRole == "UserLaundry")
            //{
            //    return new GetAllLiquidationDocumentsResponse
            //    {
            //        Error = new ErrorModel(ErrorType.Unauthorized)
            //    };
            
            var query = new GetLiquidationDocumentsQuery()
            {
                LiquidationDocNumber = request.LiquidationDocNumber
            };
            var liquidationDoc = await this.queryExecutor.Execute(query);

            if (liquidationDoc == null)
            {
                return new GetAllLiquidationDocumentsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mapppedLiquidationDoc = this.mapper.Map<List<Domain.Models.LiquidationDocument>>(liquidationDoc);

            var response = new GetAllLiquidationDocumentsResponse
            {
                Data = mapppedLiquidationDoc
            };
            return response;

        }
    }
}
