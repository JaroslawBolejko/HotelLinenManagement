using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
   public class GetGoodsReceivedNotesHandler : IRequestHandler<GetAllGoodsRecivedNotesRequest, GetAllGoodsRecivedNotesResponse>
    {
        private readonly IRepository<GoodsReceivedNote> goodsRecivedNotesRepository;
        private readonly IMapper mapper;

        public GetGoodsReceivedNotesHandler(IRepository<DataAccess.Entities.GoodsReceivedNote> goodsRecivedNotesRepository, IMapper mapper)
        {
            this.goodsRecivedNotesRepository = goodsRecivedNotesRepository;
            this.mapper = mapper;
        }

        public async Task<GetAllGoodsRecivedNotesResponse> Handle(GetAllGoodsRecivedNotesRequest request, CancellationToken cancellationToken)
        {
            var goodsReceivedNote = await this.goodsRecivedNotesRepository.GetAll();
            var mappedGoodsReceivedNote = this.mapper.Map<List<Domain.Models.GoodsReceivedNote>>(goodsReceivedNote);

            var response = new GetAllGoodsRecivedNotesResponse()
            {
                Data = mappedGoodsReceivedNote
            };
            return response;
        }
    }
}
