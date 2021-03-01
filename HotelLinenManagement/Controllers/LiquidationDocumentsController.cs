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
    }
}
