using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class HotelsProfile : Profile
    {
        public HotelsProfile()
        {
            this.CreateMap<DeleteHotelByIdRequest, DataAccess.Entities.Hotel>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<PutHotelByIdRequest, DataAccess.Entities.Hotel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.HotelName, y => y.MapFrom(z => z.HotelName));

            this.CreateMap<AddHotelRequest, DataAccess.Entities.Hotel>()
                .ForMember(x => x.HotelName, y => y.MapFrom(z => z.HotelName));

            this.CreateMap<DataAccess.Entities.Hotel, Hotel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.HotelName, y => y.MapFrom(z => z.HotelName));
            // .ForMember(x => x.Storerooms, y => y.MapFrom(z => z.Storerooms))
            //  .ForMember(x => x.HotelLinens, y => y.MapFrom(z => z.HotelLinens));
        }
    }
}