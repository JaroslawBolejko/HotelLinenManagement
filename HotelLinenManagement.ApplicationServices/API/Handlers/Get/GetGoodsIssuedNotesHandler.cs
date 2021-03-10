using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetGoodsIssuedNotesHandler : IRequestHandler<GetAllGoodsIssuedNotesRequest, GetAllGoodsIssuedNotesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetGoodsIssuedNotesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllGoodsIssuedNotesResponse> Handle(GetAllGoodsIssuedNotesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGoodsIssuedNotesQuery()
            {
                GoodsIssuedNoteNumber=request.GoodsIssuedNoteNumber
            };
            var goodsIssuedNote = await this.queryExecutor.Execute(query);
            var mappedGoodsIssuedNote = this.mapper.Map<List<Domain.Models.GoodsIssuedNote>>(goodsIssuedNote);

            var response = new GetAllGoodsIssuedNotesResponse()
            {
                Data = mappedGoodsIssuedNote
            };
            return response;
        }
    }
}
