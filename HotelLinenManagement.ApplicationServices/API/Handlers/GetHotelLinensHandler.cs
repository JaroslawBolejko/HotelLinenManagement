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
    class GetHotelLinensHandler : IRequestHandler<GetHotelLinenRequest, GetHotelLinenResponse>
    {
        private readonly IRepository<HotelLinen> hotelLinenRepository;

        public GetHotelLinensHandler(IRepository<DataAccess.Entities.HotelLinen> hotelLinenRepository)
        {
            this.hotelLinenRepository = hotelLinenRepository;
        }

        public Task<GetHotelLinenResponse> Handle(GetHotelLinenRequest request, CancellationToken cancellationToken)
        {
            var hotleLinens = this.hotelLinenRepository.GetAll();
            var domainHotelLinens = hotleLinens.Select(x => new Domain.Models.HotelLinen()
            {
                Id = x.Id,
                LinenName = x.LinenName,
                LinenType = x.LinenType,
                LinenAmount = x.LinenAmount,
                LinienWeight = x.LinienWeight
            });

            var response = new GetHotelLinenResponse()
            {
                Data = domainHotelLinens.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
