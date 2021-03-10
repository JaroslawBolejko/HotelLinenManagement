using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Commands.Invoices;
using HotelLinenManagement.DataAccess.CQRS.Commands.Laundries;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.API.Handlers.Add
{
    public class PutInvoiceByIdHandler : IRequestHandler<PutInvoiceByIdRequest, PutInvoiceByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutInvoiceByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutInvoiceByIdResponse> Handle(PutInvoiceByIdRequest request, CancellationToken cancellationToken)
        {
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
