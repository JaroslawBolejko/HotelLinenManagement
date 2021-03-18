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

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteInvoiceByIdHandler : IRequestHandler<DeleteInvoiceByIdRequest, DeleteInvoiceByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteInvoiceByIdHandler(IMapper mapper,IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteInvoiceByIdResponse> Handle(DeleteInvoiceByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteInvoiceByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var invoice = this.mapper.Map<Invoice>(request);
            var command = new DeleteInvoiceByIdCommand()
            {
                Parameter = invoice
            };
            var invoicefromDb = await this.commandExecutor.Execute(command);

            return new DeleteInvoiceByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Invoice>(invoicefromDb)
            };
        }
    }
}
