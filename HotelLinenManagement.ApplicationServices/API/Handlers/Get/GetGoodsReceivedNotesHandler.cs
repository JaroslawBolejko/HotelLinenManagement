using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.GoodsReceivedNotes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetGoodsReceivedNotesHandler : IRequestHandler<GetAllGoodsRecivedNotesRequest, GetAllGoodsRecivedNotesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetGoodsReceivedNotesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllGoodsRecivedNotesResponse> Handle(GetAllGoodsRecivedNotesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGoodsReceivedNotesQuery()
            {
                GoodsReceivedNoteNumber=request.GoodsReceivedNoteNumber
            };
            var goodsReceivedNote = await this.queryExecutor.Execute(query);

            if (goodsReceivedNote == null)
            {
                return new GetAllGoodsRecivedNotesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedGoodsReceivedNote = this.mapper.Map<List<Domain.Models.GoodsReceivedNote>>(goodsReceivedNote);

            var response = new GetAllGoodsRecivedNotesResponse()
            {
                Data = mappedGoodsReceivedNote
            };
            return response;
        }
    }
}
