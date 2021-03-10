using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Invoices;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdRequest, GetInvoiceByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetInvoiceByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetInvoiceByIdResponse> Handle(GetInvoiceByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceQuery()
            {
                Id = request.Id
            };
            var invoice = await this.queryExecutor.Execute(query);
            var mappedInvoice = this.mapper.Map<Domain.Models.Invoice>(invoice);
            var response = new GetInvoiceByIdResponse()
            {
                Data = mappedInvoice
            };
            return response;
        }
    }
}
