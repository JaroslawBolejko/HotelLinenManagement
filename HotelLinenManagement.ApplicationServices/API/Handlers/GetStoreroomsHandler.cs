using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    class GetStoreroomsHandler : IRequestHandler<GetAllStoreroomsRequest, GetAllStoreroomsResponse>
    {
        private readonly IRepository<Storeroom> storeroomRepository;

        public GetStoreroomsHandler(IRepository<DataAccess.Entities.Storeroom> storeroomRepository)
        {
            this.storeroomRepository = storeroomRepository;
        }

        public Task<GetAllStoreroomsResponse> Handle(GetAllStoreroomsRequest request, CancellationToken cancellationToken)
        {
            var storerooms = this.storeroomRepository.GetAll();
            var domainStorerooms = storerooms.Select(x => new Domain.Models.Storeroom()
            {
                RoomNumber = x.RoomNumber,
                StoreRoomName = x.StoreRoomName,
                ReciptDate = x.ReciptDate,
                IssueDate = x.IssueDate
            });
        

        var response = new GetAllStoreroomsResponse()
            {
                Data = domainStorerooms.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
