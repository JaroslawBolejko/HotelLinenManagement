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
    class GetLinenTypesHandler : IRequestHandler<GetAllLinenTypesRequest, GetAllLinenTypesResponse>
    {
        private readonly IRepository<LinienType> linenTypesRepository;

        public GetLinenTypesHandler(IRepository<DataAccess.Entities.LinienType> linenTypesRepository)
        {
            this.linenTypesRepository = linenTypesRepository;
        }

        public Task<GetAllLinenTypesResponse> Handle(GetAllLinenTypesRequest request, CancellationToken cancellationToken)
        {
            var linenTypes = this.linenTypesRepository.GetAll();
            var domainLinenTypes = linenTypes.Select(x => new Domain.Models.LinenType()
            {

                LinienTypeName = x.LinienTypeName
                

            });

            var response = new GetAllLinenTypesResponse()
            {
                Data = domainLinenTypes.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
