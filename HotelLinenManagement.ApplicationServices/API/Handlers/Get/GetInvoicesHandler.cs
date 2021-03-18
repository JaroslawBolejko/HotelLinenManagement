using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Invoices;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetInvoicesHandler : IRequestHandler<GetAllInvoicesRequest, GetAllInvoicesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetInvoicesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllInvoicesResponse> Handle(GetAllInvoicesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoicesQuery()
            {
                HotelId = request.HotelId,
                LaundryId = request.LaundryId
            };

            var invoice = await this.queryExecutor.Execute(query);

            if (invoice == null)
            {
                return new GetAllInvoicesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedInvoice = this.mapper.Map<List<Domain.Models.Invoice>>(invoice);

            var response = new GetAllInvoicesResponse()
            {
                Data = mappedInvoice
            };
            return response;
        }
    }
}
