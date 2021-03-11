using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.GoodsReceivedNotes;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutGoodsReceivedNoteHandler : IRequestHandler<PutGoodsReceivedNotesByIdRequest, PutGoodsReceivedNotesByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutGoodsReceivedNoteHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutGoodsReceivedNotesByIdResponse> Handle(PutGoodsReceivedNotesByIdRequest request, CancellationToken cancellationToken)
        {
            var goodsReceivedNote = this.mapper.Map<GoodsReceivedNote>(request);
            var command = new PutGoodsReceivedNoteByIdCommand()
            {
                Parameter = goodsReceivedNote
            };
            var goodsReceivedNoteUpdated = await this.commandExecutor.Execute(command);

            return new PutGoodsReceivedNotesByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.GoodsReceivedNote>(goodsReceivedNoteUpdated)
            };
        }
    }
}
