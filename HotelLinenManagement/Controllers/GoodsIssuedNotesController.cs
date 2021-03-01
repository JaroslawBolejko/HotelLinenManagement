using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GoodsIssuedNotesController : ControllerBase
    {
        private readonly IMediator mediator;

        public GoodsIssuedNotesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGoodsIssuedNotes([FromQuery] GetAllGoodsIssuedNotesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
