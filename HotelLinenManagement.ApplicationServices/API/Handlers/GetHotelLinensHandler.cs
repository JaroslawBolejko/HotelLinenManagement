using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    class GetHotelLinensHandler : IRequestHandler<GetAllHotelLinensRequest, GetAllHotelLinensResponse>
    {
        private readonly IRepository<HotelLinen> hotelLinenRepository;
        private readonly IMapper mapper;

        public GetHotelLinensHandler(IRepository<DataAccess.Entities.HotelLinen> hotelLinenRepository, IMapper mapper)
        {
            this.hotelLinenRepository = hotelLinenRepository;
            this.mapper = mapper;
        }

        public Task<GetAllHotelLinensResponse> Handle(GetAllHotelLinensRequest request, CancellationToken cancellationToken)
        {
            var hotelLinens = this.hotelLinenRepository.GetAll();
            var mappedHotelLinen = this.mapper.Map<List<Domain.Models.HotelLinen>>(hotelLinens);
           

            var response = new GetAllHotelLinensResponse()
            {
                Data = mappedHotelLinen
            };
            return Task.FromResult(response);
        }
    }
}
