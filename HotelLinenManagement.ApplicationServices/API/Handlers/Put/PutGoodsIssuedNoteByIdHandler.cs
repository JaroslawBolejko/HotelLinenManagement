using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess.CQRS.Queries.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutGoodsIssuedNoteHandler : IRequestHandler<PutGoodsIssuedNoteByIdRequest, PutGoodsIssuedNoteByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public PutGoodsIssuedNoteHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<PutGoodsIssuedNoteByIdResponse> Handle(PutGoodsIssuedNoteByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGoodsIssuedNoteQuery()
            {
                Id = request.Id
            };

            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new PutGoodsIssuedNoteByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var goodsIssuedNote = this.mapper.Map<GoodsIssuedNote>(request);
            var command = new PutGoodsIssuedNoteByIdCommand()
            {
                Parameter = goodsIssuedNote
            };
            var goodsIssuedNoteUpdated = await this.commandExecutor.Execute(command);

            return new PutGoodsIssuedNoteByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.GoodsIssuedNote>(goodsIssuedNoteUpdated)
            };
        }
    }
}
