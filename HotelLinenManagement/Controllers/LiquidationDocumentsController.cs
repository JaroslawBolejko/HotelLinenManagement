using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LiquidationDocuments;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LiquidationDocuments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LiquidationDocumentsController : ApiControllerBase
    {

        public LiquidationDocumentsController(IMediator mediator, ILogger<LiquidationDocumentsController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in Liquidation Documents ");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllLiquidationDocuments([FromQuery] GetAllLiquidationsDocumentsRequest request)
        {
            return this.HandleRequest<GetAllLiquidationsDocumentsRequest, GetAllLiquidationDocumentsResponse>(request);
        }

        [HttpGet]
        [Route("{liquidationDocumentId}")]
        public  Task<IActionResult> GetById([FromRoute] int liquidationDocumentId)
        {

            var request = new GetLiquidationDocumentByIdRequest()
            {
                Id = liquidationDocumentId
            };
            return this.HandleRequest<GetLiquidationDocumentByIdRequest, GetLiquidationDocumentByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddLiquidationDocument([FromQuery] AddLiquidationDocumentRequest request)
        {
            return this.HandleRequest<AddLiquidationDocumentRequest, AddLiquidationDocumentResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutLiquidationDocumentById([FromQuery] PutLiquidationDocumentByIdRequest request)
        {
            return this.HandleRequest<PutLiquidationDocumentByIdRequest, PutLiquidationDocumentByIdResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteLiquidationDocumentById([FromQuery] DeleteLiquidationDocumentByIdRequest request)
        {
            return this.HandleRequest<DeleteLiquidationDocumentByIdRequest, DeleteLiquidationDocumentByIdResponse>(request);
        }

    }
}
