using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class LiquidationDocumentsProfile : Profile
    {
        public LiquidationDocumentsProfile()
        {
            this.CreateMap<DataAccess.Entities.LiquidationDocument, LiquidationDocument>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LiquidationDocName, y => y.MapFrom(z => z.DocumentName))
                .ForMember(x => x.LiquidationDocNumber, y => y.MapFrom(z => z.DocumentNumber))
                .ForMember(x => x.LiquidationDocDate, y => y.MapFrom(z => z.DocumentDate))
                .ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
                .ForMember(x => x.HotelLinen, y => y.MapFrom(z => z.HotelLinen))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User));
             
        }
    }
}





