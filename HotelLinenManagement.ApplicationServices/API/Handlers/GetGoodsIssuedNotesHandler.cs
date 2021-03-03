using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetGoodsIssuedNotesHandler : IRequestHandler<GetAllGoodsIssuedNotesRequest, GetAllGoodsIssuedNotesResponse>
    {
        private readonly IRepository<GoodsIssuedNote> goodsIssuedNotesRepository;
        private readonly IMapper mapper;

        public GetGoodsIssuedNotesHandler(IRepository<DataAccess.Entities.GoodsIssuedNote> goodsIssuedNotesRepository, IMapper mapper)
        {
            this.goodsIssuedNotesRepository = goodsIssuedNotesRepository;
            this.mapper = mapper;
        }

        public Task<GetAllGoodsIssuedNotesResponse> Handle(GetAllGoodsIssuedNotesRequest request, CancellationToken cancellationToken)
        {
            var goodsIssuedNote = this.goodsIssuedNotesRepository.GetAll();
            var mappedGoodsIssuedNote = this.mapper.Map<List<Domain.Models.GoodsIssuedNote>>(goodsIssuedNote);

            var response = new GetAllGoodsIssuedNotesResponse()
            {
                Data = mappedGoodsIssuedNote
            };
            return Task.FromResult(response);
        }
    }
}
