using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
   public class GetLaundriesHandler : IRequestHandler<GetAllLaundriesRequest, GetAllLaundriesResponse>
    {
        private readonly IRepository<Laundry> laundryRepository;
        private readonly IMapper mapper;

        public GetLaundriesHandler(IRepository<DataAccess.Entities.Laundry> laundryRepository, IMapper mapper)
        {
            this.laundryRepository = laundryRepository;
            this.mapper = mapper;
        }

        public Task<GetAllLaundriesResponse> Handle(GetAllLaundriesRequest request, CancellationToken cancellationToken)
        {
            var laundries = this.laundryRepository.GetAll();
            var mappedLaundry = this.mapper.Map<List<Domain.Models.Laundry>>(laundries);


            var response = new GetAllLaundriesResponse()
            {
                Data = mappedLaundry
            };
            return Task.FromResult(response);
        }
    }
}
