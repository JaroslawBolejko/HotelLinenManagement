using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class GoodsIssuedNotesProfile : Profile
    {
        public GoodsIssuedNotesProfile()
        {
            this.CreateMap<DataAccess.Entities.GoodsIssuedNote, GoodsIssuedNote>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.GoodsIssuedNoteName, y => y.MapFrom(z => z.DocumentName))
                .ForMember(x => x.GoodsIssuedNoteNumber, y => y.MapFrom(z => z.DocumentNumber))
                .ForMember(x => x.GoodsIssuedNoteDate, y => y.MapFrom(z => z.DocumentDate))
                .ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
                .ForMember(x => x.HotelLinen, y => y.MapFrom(z => z.HotelLinen))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User));

        }
    }
}
