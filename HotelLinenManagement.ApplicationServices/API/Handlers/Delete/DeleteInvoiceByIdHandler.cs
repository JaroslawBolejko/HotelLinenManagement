using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Invoices;
using HotelLinenManagement.DataAccess.CQRS.Commands.Laundries;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Delete
{
    public class DeleteInvoiceByIdHandler : IRequestHandler<DeleteInvoiceByIdRequest, DeleteInvoiceByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteInvoiceByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteInvoiceByIdResponse> Handle(DeleteInvoiceByIdRequest request, CancellationToken cancellationToken)
        {
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
