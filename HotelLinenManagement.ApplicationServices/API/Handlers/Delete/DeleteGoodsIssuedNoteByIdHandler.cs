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

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteGoodsIssuedNoteByIHandler : IRequestHandler<DeleteGoodsIssuedNoteByIdRequest, DeleteGoodsIssuedNoteByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteGoodsIssuedNoteByIHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteGoodsIssuedNoteByIdResponse> Handle(DeleteGoodsIssuedNoteByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGoodsIssuedNoteQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteGoodsIssuedNoteByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var goodsIssuedNote = this.mapper.Map<GoodsIssuedNote>(request);
            var command = new DeleteGoodsIssuedNoteByIdCommand()
            {
                Parameter = goodsIssuedNote
            };
            var goodsIssuedNoteFromDb = await this.commandExecutor.Execute(command);

            return new DeleteGoodsIssuedNoteByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.GoodsIssuedNote>(goodsIssuedNoteFromDb)
            };
        }
    }
}
