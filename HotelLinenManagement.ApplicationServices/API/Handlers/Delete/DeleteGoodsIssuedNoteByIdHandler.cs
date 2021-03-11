using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteGoodsIssuedNoteByIHandler : IRequestHandler<DeleteGoodsIssuedNoteByIdRequest, DeleteGoodsIssuedNoteByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteGoodsIssuedNoteByIHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteGoodsIssuedNoteByIdResponse> Handle(DeleteGoodsIssuedNoteByIdRequest request, CancellationToken cancellationToken)
        {
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
