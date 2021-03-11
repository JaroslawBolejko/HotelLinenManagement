using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class GoodsReceivedNotesProfile : Profile
    {
        public GoodsReceivedNotesProfile()
        {
            this.CreateMap<DeleteGoodsReceivedNotesByIdRequest, DataAccess.Entities.GoodsReceivedNote>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<PutGoodsReceivedNotesByIdRequest, DataAccess.Entities.GoodsReceivedNote>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.DocumentName, y => y.MapFrom(z => z.GoodsReceivedNoteName))
               .ForMember(x => x.DocumentNumber, y => y.MapFrom(z => z.GoodsReceivedNoteNumber))
               .ForMember(x => x.DocumentDate, y => y.MapFrom(z => z.GoodsReceivedNoteDate));

            this.CreateMap<AddGoodsReceivedNoteRequest, DataAccess.Entities.GoodsReceivedNote>()
               .ForMember(x => x.DocumentName, y => y.MapFrom(z => z.GoodsReceivedNoteName))
               .ForMember(x => x.DocumentNumber, y => y.MapFrom(z => z.GoodsReceivedNoteNumber))
               .ForMember(x => x.DocumentDate, y => y.MapFrom(z => z.GoodsReceivedNoteDate));

            this.CreateMap<DataAccess.Entities.GoodsReceivedNote, GoodsReceivedNote>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.GoodsReceivedNoteName, y => y.MapFrom(z => z.DocumentName))
                .ForMember(x => x.GoodsReceivedNoteNumber, y => y.MapFrom(z => z.DocumentNumber))
                .ForMember(x => x.GoodsReceivedNoteDate, y => y.MapFrom(z => z.DocumentDate));
               // .ForMember(x => x.HotelId, y => y.MapFrom(z => z.HotelId));
                //.ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
                //.ForMember(x => x.HotelLinen, y => y.MapFrom(z => z.HotelLinen))
                //.ForMember(x => x.User, y => y.MapFrom(z => z.User));

        }
    }
}
