using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.GoodsReceivedNotes;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetGoodsReceivedNoteByIdHandler : IRequestHandler<GetGoodsReceivedNoteByIdRequest, GetGoodsReceivedNoteByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetGoodsReceivedNoteByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetGoodsReceivedNoteByIdResponse> Handle(GetGoodsReceivedNoteByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGoodsReceivedNoteQuery()
            {
                Id = request.Id
            };
            var goodsReceivedNote = await this.queryExecutor.Execute(query);

            if (goodsReceivedNote == null)
            {
                return new GetGoodsReceivedNoteByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedGoodsReceivedNote = this.mapper.Map<Domain.Models.GoodsReceivedNote>(goodsReceivedNote);
            var response = new GetGoodsReceivedNoteByIdResponse()
            {
                Data = mappedGoodsReceivedNote
            };
            return response;
        }
    }
}
