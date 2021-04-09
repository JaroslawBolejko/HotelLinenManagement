using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Invoices;
using HotelLinenManagement.DataAccess.CQRS.Queries.Invoices;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutInvoiceByIdHandler : IRequestHandler<PutInvoiceByIdRequest, PutInvoiceByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public PutInvoiceByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<PutInvoiceByIdResponse> Handle(PutInvoiceByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserHotel")
            {
                return new PutInvoiceByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetInvoiceQuery()
            {
                Id = request.Id
            };

            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new PutInvoiceByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var invoice = this.mapper.Map<Invoice>(request);
            var command = new PutInvoiceByIdCommand()
            {
                Parameter = invoice
            };
            var invoicefromDb = await this.commandExecutor.Execute(command);

            return new PutInvoiceByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Invoice>(invoicefromDb)
            };
        }
    }
}
