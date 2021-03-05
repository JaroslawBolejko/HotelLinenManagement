﻿using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Models;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens;

namespace HotelLinenManagement.ApplicationServices.API.Mappings
{
    public class HotelLinensProfile : Profile
    {
        public HotelLinensProfile()
        {
            this.CreateMap<AddHotelLinenRequest, DataAccess.Entities.HotelLinen>()
                .ForMember(x => x.LinenName, y => y.MapFrom(z => z.LinenName));

            this.CreateMap<DataAccess.Entities.HotelLinen, HotelLinen>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LinenName, y => y.MapFrom(z => z.LinenName))
                .ForMember(x => x.LinenAmount, y => y.MapFrom(z => z.LinenAmount))
                .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
                .ForMember(x => x.Color, y => y.MapFrom(z => z.Color))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.LinienWeight, y => y.MapFrom(z => z.LinienWeight))
                .ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
                .ForMember(x => x.Invoices, y => y.MapFrom(z => z.Invoices))
                .ForMember(x => x.LinienTypes, y => y.MapFrom(z => z.LinienTypes))
                .ForMember(x => x.GoodsReceivedNotes, y => y.MapFrom(z => z.GoodsReceivedNotes))
                .ForMember(x => x.GoodsIssuedNotes, y => y.MapFrom(z => z.GoodsIssuedNotes))
                .ForMember(x => x.LiquidationDocuments, y => y.MapFrom(z => z.LiquidationDocuments))
                .ForMember(x => x.Storeroom, y => y.MapFrom(z => z.Storeroom))
                ;
        }

    }
}