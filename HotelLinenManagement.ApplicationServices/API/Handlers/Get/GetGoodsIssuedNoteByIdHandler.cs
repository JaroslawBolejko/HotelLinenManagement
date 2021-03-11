using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.GoodsIssuedNotes;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetGoodsIssuedNoteByIdHandler : IRequestHandler<GetGoodsIssuedNoteByIdRequest, GetGoodsIssuedNoteByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetGoodsIssuedNoteByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetGoodsIssuedNoteByIdResponse> Handle(GetGoodsIssuedNoteByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGoodsIssuedNoteQuery()
            {
                Id = request.Id
            };
            var goodsIssuedNote = await this.queryExecutor.Execute(query);
            var mappedGoodsIssuedNote = this.mapper.Map<Domain.Models.GoodsIssuedNote>(goodsIssuedNote);
            var response = new GetGoodsIssuedNoteByIdResponse()
            {
                Data = mappedGoodsIssuedNote
            };
            return response;
        }
    }
}