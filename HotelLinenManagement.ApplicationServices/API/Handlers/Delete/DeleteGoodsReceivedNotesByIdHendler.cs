using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.GoodsReceivedNotes;
using HotelLinenManagement.DataAccess.CQRS.Queries.GoodsReceivedNotes;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteGoodsReceivedNoteByIHandler : IRequestHandler<DeleteGoodsReceivedNotesByIdRequest, DeleteGoodsReceivedNotesByIdResponse
>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteGoodsReceivedNoteByIHandler(IMapper mapper,IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteGoodsReceivedNotesByIdResponse> Handle(DeleteGoodsReceivedNotesByIdRequest request, CancellationToken cancellationToken)
        {
           
            var query = new GetGoodsReceivedNoteQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteGoodsReceivedNotesByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var goodsReceivedNote = this.mapper.Map<GoodsReceivedNote>(request);
            var command = new DeleteGoodsReceivedNoteByIdCommand()
            {
                Parameter = goodsReceivedNote
            };
            var goodsReceivedNoteFromDb = await this.commandExecutor.Execute(command);

            return new DeleteGoodsReceivedNotesByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.GoodsReceivedNote>(goodsReceivedNoteFromDb)
            };
        }
    }
}
