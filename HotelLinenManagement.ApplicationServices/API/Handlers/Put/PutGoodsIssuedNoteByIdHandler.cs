using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutGoodsIssuedNoteHandler : IRequestHandler<PutGoodsIssuedNoteByIdRequest, PutGoodsIssuedNoteByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutGoodsIssuedNoteHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutGoodsIssuedNoteByIdResponse> Handle(PutGoodsIssuedNoteByIdRequest request, CancellationToken cancellationToken)
        {
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
