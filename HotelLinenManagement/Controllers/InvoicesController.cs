using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Invoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class InvoicesController : ApiControllerBase
    {
        public InvoicesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public  Task<IActionResult> GetAllInvoices([FromQuery] GetAllInvoicesRequest request)
        {
            return this.HandleRequest<GetAllInvoicesRequest, GetAllInvoicesResponse>(request);
        }

        [HttpGet]
        [Route("{invoiceId}")]
        public Task<IActionResult> GetById([FromRoute] int invoiceId)
        {

            var request = new GetInvoiceByIdRequest()
            {
                Id = invoiceId
            };
            return this.HandleRequest<GetInvoiceByIdRequest, GetInvoiceByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddInvoice([FromQuery] AddInvoiceRequest request)
        {
            return this.HandleRequest<AddInvoiceRequest, AddInvoiceResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutInvoiceById([FromQuery] PutInvoiceByIdRequest request)
        {
            return this.HandleRequest<PutInvoiceByIdRequest, PutInvoiceByIdResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteInvoiceById([FromQuery] DeleteInvoiceByIdRequest request)
        {
            return this.HandleRequest<DeleteInvoiceByIdRequest, DeleteInvoiceByIdResponse>(request);
        }

    }
}
