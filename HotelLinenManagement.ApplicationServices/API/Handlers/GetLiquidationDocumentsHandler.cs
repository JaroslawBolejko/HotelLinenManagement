using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetLiquidationDocumentsHandler : IRequestHandler<GetAllLiquidationsDocumentsRequest, GetAllLiquidationDocumentsResponse>
    {
        private readonly IRepository<LiquidationDocument> liquidationDocumentRepository;
        private readonly IMapper mapper;

        public GetLiquidationDocumentsHandler(IRepository<DataAccess.Entities.LiquidationDocument> liquidationDocumentRepository, IMapper mapper)
        {
            this.liquidationDocumentRepository = liquidationDocumentRepository;
            this.mapper = mapper;
        }

        public Task<GetAllLiquidationDocumentsResponse> Handle(GetAllLiquidationsDocumentsRequest request, CancellationToken cancellationToken)
        {
            var liquidationDocument = this.liquidationDocumentRepository.GetAll();
            var mappedliquidationDocument = this.mapper.Map<List<Domain.Models.LiquidationDocument>>(liquidationDocument);

            var response = new GetAllLiquidationDocumentsResponse()
            {
                Data = mappedliquidationDocument
            };
            return Task.FromResult(response);
        }
    }
}

