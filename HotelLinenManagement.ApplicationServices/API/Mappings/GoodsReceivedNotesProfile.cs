using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class GoodsReceivedNotesProfile : Profile
    {
        public GoodsReceivedNotesProfile()
        {
            this.CreateMap<DataAccess.Entities.GoodsReceivedNote, GoodsReceivedNote>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.GoodsReceivedNoteName, y => y.MapFrom(z => z.DocumentName))
                .ForMember(x => x.GoodsReceivedNoteNumber, y => y.MapFrom(z => z.DocumentNumber))
                .ForMember(x => x.GoodsReceivedNoteDate, y => y.MapFrom(z => z.DocumentDate))
                .ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
                .ForMember(x => x.HotelLinen, y => y.MapFrom(z => z.HotelLinen))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User));

        }
    }
}
