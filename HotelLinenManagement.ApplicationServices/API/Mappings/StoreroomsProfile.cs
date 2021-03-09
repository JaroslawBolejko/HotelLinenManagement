using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class StoreroomsProfile : Profile
    {
        public StoreroomsProfile()
        {
            this.CreateMap<DeleteStoreroomsByIdRequest, DataAccess.Entities.Storeroom>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<PutStoreroomsByIdRequest, DataAccess.Entities.Storeroom>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                 .ForMember(x => x.RoomNumber, y => y.MapFrom(z => z.RoomNumber))
                 .ForMember(x => x.StoreroomName, y => y.MapFrom(z => z.StoreroomName));

            this.CreateMap<AddStoreroomRequest, DataAccess.Entities.Storeroom>()
                .ForMember(x => x.StoreroomName, y => y.MapFrom(z => z.StoreroomName));

            this.CreateMap<DataAccess.Entities.Storeroom, Storeroom>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.RoomNumber, y => y.MapFrom(z => z.RoomNumber))
                .ForMember(x => x.StoreroomName, y => y.MapFrom(z => z.StoreroomName));
            // .ForMember(x => x.ReciptDate, y => y.MapFrom(z => z.ReciptDate))
            // .ForMember(x => x.IssueDate, y => y.MapFrom(z => z.IssueDate))
            //  .ForMember(x => x.HotelLinens, y => y.MapFrom(z => z.HotelLinens));

        }
    }
}


