using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
using HotelLinenManagement.ApplicationServices.Components.GetGusDataAPIByTaxNumber;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Hotels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetHotelsHandler : IRequestHandler<GetAllHotelsRequest, GetAllHotelsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly IGUSDataConnector gUSDataConnector;

        public GetHotelsHandler(IMapper mapper, IQueryExecutor queryExecutor , IGUSDataConnector gUSDataConnector)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.gUSDataConnector = gUSDataConnector;
        }

        public async Task<GetAllHotelsResponse> Handle(GetAllHotelsRequest request, CancellationToken cancellationToken)
        {
          var daneZGUS = await this.gUSDataConnector.szukajPodmioty<RootDaneSzukajPodmioty>("5261009959");
            var query = new GetHotelsQuery()
            {
                HotelName = request.HotelName
            };
            var hotels = await this.queryExecutor.Execute(query);

            if (hotels == null)
            {
                return new GetAllHotelsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedHotel = this.mapper.Map<List<Domain.Models.Hotel>>(hotels);

            var response = new GetAllHotelsResponse()
            {
                Data = mappedHotel
            };
            return response;
        }
    }
}
