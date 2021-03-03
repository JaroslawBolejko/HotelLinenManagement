using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
    {
        private readonly IRepository<User> userRepository;
        private readonly IMapper mapper;

        public GetUsersHandler(IRepository<DataAccess.Entities.User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var user = this.userRepository.GetAll();
            var mappedUser = this.mapper.Map<List<Domain.Models.User>>(user);

            var response = new GetAllUsersResponse()
            {
                Data = mappedUser
            };
            return Task.FromResult(response);
        }
    }
}
