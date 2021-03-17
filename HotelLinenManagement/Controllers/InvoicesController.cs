using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class InvoicesController : ControllerBase
    {
        private readonly IMediator mediator;

        public InvoicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInvoices([FromQuery] GetAllInvoicesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{invoiceId}")]
        public async Task<IActionResult> GetById([FromRoute] int invoiceId)
        {

            var request = new GetInvoiceByIdRequest()
            {
                Id = invoiceId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddInvoice([FromQuery] AddInvoiceRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutInvoiceById([FromQuery] PutInvoiceByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteInvoiceById([FromQuery] DeleteInvoiceByIdRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
