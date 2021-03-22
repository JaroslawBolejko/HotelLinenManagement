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

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class AddGoodsReceivedNoteHandler : IRequestHandler<AddGoodsReceivedNoteRequest, AddGoodsReceivedNoteResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddGoodsReceivedNoteHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddGoodsReceivedNoteResponse> Handle(AddGoodsReceivedNoteRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGoodsReceivedNotesQuery()
            {
                GoodsReceivedNoteNumber = request.GoodsReceivedNoteNumber

            };
            var addNewResource = await queryExecutor.Execute(query);

            if (addNewResource != null)
            {
                return new AddGoodsReceivedNoteResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };

            }

            var goodsReceivedNote = this.mapper.Map<GoodsReceivedNote>(request);
            var command = new AddGoodsReceivedNoteCommand()
            {
                Parameter = goodsReceivedNote
            };
            var goodsReceivedNoteFromDb = await this.commandExecutor.Execute(command);

            return new AddGoodsReceivedNoteResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.GoodsReceivedNote>(goodsReceivedNoteFromDb)
            };

        }
    }
}
