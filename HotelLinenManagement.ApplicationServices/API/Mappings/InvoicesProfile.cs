using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            this.CreateMap<DeleteInvoiceByIdRequest, DataAccess.Entities.Invoice>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<PutInvoiceByIdRequest, DataAccess.Entities.Invoice>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.InvoiceTotal, y => y.MapFrom(z => z.InvoiceTotal))
                .ForMember(x => x.HotelId, y => y.MapFrom(z => z.HotelId))
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
                .ForMember(x => x.DocumentName, y => y.MapFrom(z => z.DocumentName))
                .ForMember(x => x.DocumentNumber, y => y.MapFrom(z => z.DocumentNumber))
                .ForMember(x => x.DocumentDate, y => y.MapFrom(z => z.DocumentDate)); ;


            this.CreateMap<AddInvoiceRequest, DataAccess.Entities.Invoice>()
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.InvoiceTotal, y => y.MapFrom(z => z.InvoiceTotal))
                .ForMember(x => x.HotelId, y => y.MapFrom(z => z.HotelId))
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
                .ForMember(x => x.DocumentName, y => y.MapFrom(z => z.DocumentName))
                .ForMember(x => x.DocumentNumber, y => y.MapFrom(z => z.DocumentNumber))
                .ForMember(x => x.DocumentDate, y => y.MapFrom(z => z.DocumentDate));

            this.CreateMap<DataAccess.Entities.Invoice, Invoice>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.InvoiceTotal, y => y.MapFrom(z => z.InvoiceTotal))
               .ForMember(x => x.HotelId, y => y.MapFrom(z => z.HotelId))
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
                .ForMember(x => x.DocumentName, y => y.MapFrom(z => z.DocumentName))
                .ForMember(x => x.DocumentNumber, y => y.MapFrom(z => z.DocumentNumber))
                .ForMember(x => x.DocumentDate, y => y.MapFrom(z => z.DocumentDate));
            // .ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
            //  .ForMember(x => x.Laundry, y => y.MapFrom(z => z.Laundry));

        }
    }
}