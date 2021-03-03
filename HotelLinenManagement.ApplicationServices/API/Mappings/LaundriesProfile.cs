using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class LaundriesProfile : Profile
    {
        public LaundriesProfile()
        {
            this.CreateMap<DataAccess.Entities.Laundry, Laundry>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.TaxNumber, y => y.MapFrom(z => z.TaxNumber))
                .ForMember(x => x.ReciptDate, y => y.MapFrom(z => z.ReciptDate))
                .ForMember(x => x.IssueDate, y => y.MapFrom(z => z.IssueDate))
                .ForMember(x => x.Invoices, y => y.MapFrom(z => z.Invoices))
                .ForMember(x => x.HotelLinens, y => y.MapFrom(z => z.HotelLinens))
                .ForMember(x => x.GoodsReceivedNotes, y => y.MapFrom(z => z.GoodsReceivedNotes))
                .ForMember(x => x.GoodsIssuedNotes, y => y.MapFrom(z => z.GoodsIssuedNotes));
        }
    }
}



