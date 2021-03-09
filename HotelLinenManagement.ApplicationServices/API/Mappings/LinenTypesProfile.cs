using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class LinenTypesProfile : Profile
    {
        public LinenTypesProfile()
        {
            this.CreateMap<DataAccess.Entities.LinenType, LinenType>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LinenTypeName, y => y.MapFrom(z => z.LinenTypeName));
                //.ForMember(x => x.HotelLinen, y => y.MapFrom(z => z.HotelLinen));
                
        }
    }
}