using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LiquidationDocumentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public LiquidationDocumentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllLiquidationDocuments([FromQuery] GetAllLiquidationsDocumentsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{liquidationDocumentId}")]
        public async Task<IActionResult> GetById([FromRoute] int liquidationDocumentId)
        {

            var request = new GetLiquidationDocumentByIdRequest()
            {
               Id = liquidationDocumentId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddLiquidationDocument([FromQuery] AddLiquidationDocumentRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutLiquidationDocumentById([FromQuery] PutLiquidationDocumentByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteLiquidationDocumentById([FromQuery] DeleteLiquidationDocumentByIdRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
