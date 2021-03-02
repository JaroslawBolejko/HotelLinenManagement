using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class HotelLinensProfile : Profile
    {
        public HotelLinensProfile()
        {
            this.CreateMap<DataAccess.Entities.HotelLinen, HotelLinen>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LinenName, y => y.MapFrom(z => z.LinenName))
                .ForMember(x => x.LinenAmount, y => y.MapFrom(z => z.LinenAmount))
                .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
                .ForMember(x => x.Color, y => y.MapFrom(z => z.Color))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.LinienWeight, y => y.MapFrom(z => z.LinienWeight))
                .ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
                .ForMember(x => x.Invices, y => y.MapFrom(z => z.Invices))
                .ForMember(x => x.LinienTypes, y => y.MapFrom(z => z.LinienTypes))
                .ForMember(x => x.GoodsReceivedNotes, y => y.MapFrom(z => z.GoodsReceivedNotes))
                .ForMember(x => x.GoodsIssuedNotes, y => y.MapFrom(z => z.GoodsIssuedNotes))
                .ForMember(x => x.LiquidationDocuments, y => y.MapFrom(z => z.LiquidationDocuments));
        }

    }
}
