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
    public class AddGoodsIssuedNoteHandler : IRequestHandler<AddGoodsIssuedNoteRequest, AddGoodsIssuedNoteResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddGoodsIssuedNoteHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddGoodsIssuedNoteResponse> Handle(AddGoodsIssuedNoteRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGoodsIssuedNotesQuery()
            {
                GoodsIssuedNoteNumber = request.GoodsIssuedNoteNumber

            };
            var addNewResource = await queryExecutor.Execute(query);

            if (addNewResource != null)
            {
                return new AddGoodsIssuedNoteResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };

            }
            var goodsIssuedNote = this.mapper.Map<GoodsIssuedNote>(request);
            var command = new AddGoodsIssuedNoteCommand()
            {
                Parameter = goodsIssuedNote
            };
            var goodsIssuedNoteFromDb = await this.commandExecutor.Execute(command);

            return new AddGoodsIssuedNoteResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.GoodsIssuedNote>(goodsIssuedNoteFromDb)
            };

        }
    }
}
