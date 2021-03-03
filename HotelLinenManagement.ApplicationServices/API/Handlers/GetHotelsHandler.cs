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
  public  class GetHotelsHandler : IRequestHandler<GetAllHotelsRequest, GetAllHotelsResponse>
    {
        private readonly IRepository<Hotel> hotelRepository;
        private readonly IMapper mapper;

        public GetHotelsHandler(IRepository<DataAccess.Entities.Hotel> hotelRepository, IMapper mapper)
        {
            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
        }

        public async Task<GetAllHotelsResponse> Handle(GetAllHotelsRequest request, CancellationToken cancellationToken)
        {
            var hotels = await this.hotelRepository.GetAll();
            var mappedHotel = this.mapper.Map<List<Domain.Models.Hotel>>(hotels);
                        
            var response = new GetAllHotelsResponse()
            {
                Data = mappedHotel
            };
            return response;
        }
    }
}
