using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetStoreroomsHandler : IRequestHandler<GetAllStoreroomsRequest, GetAllStoreroomsResponse>
    {
        private readonly IRepository<Storeroom> storeroomRepository;
        private readonly IMapper mapper;

        public GetStoreroomsHandler(IRepository<DataAccess.Entities.Storeroom> storeroomRepository,IMapper mapper)
        {
            this.storeroomRepository = storeroomRepository;
            this.mapper = mapper;
        }

        public Task<GetAllStoreroomsResponse> Handle(GetAllStoreroomsRequest request, CancellationToken cancellationToken)
        {
            var storerooms = this.storeroomRepository.GetAll();
            var mappedStoreroom = this.mapper.Map<List<Domain.Models.Storeroom>>(storerooms);

        var response = new GetAllStoreroomsResponse()
            {
                Data = mappedStoreroom
            };
            return Task.FromResult(response);
        }
    }
}
