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
    public class GetLinenTypesHandler : IRequestHandler<GetAllLinenTypesRequest, GetAllLinenTypesResponse>
    {
        private readonly IRepository<LinenType> linenTypesRepository;
        private readonly IMapper mapper;

        public GetLinenTypesHandler(IRepository<DataAccess.Entities.LinenType> linenTypesRepository,IMapper mapper)
        {
            this.linenTypesRepository = linenTypesRepository;
            this.mapper = mapper;
        }

        public Task<GetAllLinenTypesResponse> Handle(GetAllLinenTypesRequest request, CancellationToken cancellationToken)
        {
            var linenTypes = this.linenTypesRepository.GetAll();
            var mappedLinenType = this.mapper.Map<List<Domain.Models.LinenType>>(linenTypes);

            var response = new GetAllLinenTypesResponse()
            {
                Data = mappedLinenType
            };
            return Task.FromResult(response);
        }
    }
}
