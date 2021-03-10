using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            this.CreateMap<DataAccess.Entities.Invoice, Invoice>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.InvoiceTotal, y => y.MapFrom(z => z.InvoiceTotal))
               //.ForMember(x => x.HotelId, y => y.MapFrom(z => z.HotelId))
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId));
               // Tu z tymi migracjami jest coś nie tak                           
        // .ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
        //  .ForMember(x => x.Laundry, y => y.MapFrom(z => z.Laundry));

    }
    }
}