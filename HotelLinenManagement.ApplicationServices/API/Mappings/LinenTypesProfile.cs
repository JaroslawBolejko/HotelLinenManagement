using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class LinenTypesProfile : Profile
    {
        public LinenTypesProfile()
        {
            this.CreateMap<DeleteLinenTypeByIdRequest, DataAccess.Entities.LinenType>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<PutLinenTypeByIdRequest, DataAccess.Entities.LinenType>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LinenTypeName, y => y.MapFrom(z => z.LinenTypeName));

            this.CreateMap<AddLinenTypeRequest, DataAccess.Entities.LinenType>()
                .ForMember(x => x.LinenTypeName, y => y.MapFrom(z => z.LinenTypeName));

            this.CreateMap<DataAccess.Entities.LinenType, LinenType>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LinenTypeName, y => y.MapFrom(z => z.LinenTypeName));
                //.ForMember(x => x.HotelLinen, y => y.MapFrom(z => z.HotelLinen));
                
        }
    }
}