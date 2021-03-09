using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class LiquidationDocumentsProfile : Profile
    {
        public LiquidationDocumentsProfile()
        {
            this.CreateMap<DeleteLiquidationDocumentByIdRequest, DataAccess.Entities.LiquidationDocument>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<PutLiquidationDocumentByIdRequest, DataAccess.Entities.LiquidationDocument>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
             .ForMember(x => x.DocumentName, y => y.MapFrom(z => z.LiquidationDocName))
             .ForMember(x => x.DocumentNumber, y => y.MapFrom(z => z.LiquidationDocNumber))
             .ForMember(x => x.DocumentDate, y => y.MapFrom(z => z.LiquidationDocDate));

            this.CreateMap<AddLiquidationDocumentRequest, DataAccess.Entities.LiquidationDocument>()
             .ForMember(x => x.DocumentName, y => y.MapFrom(z => z.LiquidationDocName))
             .ForMember(x => x.DocumentNumber, y => y.MapFrom(z => z.LiquidationDocNumber))
             .ForMember(x => x.DocumentDate, y => y.MapFrom(z => z.LiquidationDocDate));

            this.CreateMap<DataAccess.Entities.LiquidationDocument, LiquidationDocument>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
             .ForMember(x => x.LiquidationDocName, y => y.MapFrom(z => z.DocumentName))
             .ForMember(x => x.LiquidationDocNumber, y => y.MapFrom(z => z.DocumentNumber))
             .ForMember(x => x.LiquidationDocDate, y => y.MapFrom(z => z.DocumentDate));
            //.ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
            // .ForMember(x => x.HotelLinen, y => y.MapFrom(z => z.HotelLinen))
            //.ForMember(x => x.User, y => y.MapFrom(z => z.User));

        }
    }
}





