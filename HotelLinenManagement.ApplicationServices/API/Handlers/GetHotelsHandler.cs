using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    class GetHotelsHandler : IRequestHandler<GetAllHotelsRequest, GetAllHotelsResponse>
    {
        private readonly IRepository<Hotel> hotelRepository;

        public GetHotelsHandler(IRepository<DataAccess.Entities.Hotel> hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public Task<GetAllHotelsResponse> Handle(GetAllHotelsRequest request, CancellationToken cancellationToken)
        {
            var hotels = this.hotelRepository.GetAll();
            var domainHotels = hotels.Select(x => new Domain.Models.Hotel()
            {
                Id = x.Id,
                HotelName = x.HotelName,
                //Storerooms = x.Storerooms.Select(y => new Domain.Models.Storeroom()
                //{
                //    StoreRoomName = y.StoreRoomName

                //}).ToList()
               
            });

            var response = new GetAllHotelsResponse()
            {
                Data = domainHotels.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
