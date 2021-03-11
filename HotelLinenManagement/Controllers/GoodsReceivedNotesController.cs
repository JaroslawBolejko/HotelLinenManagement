using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodsReceivedNotesController : ControllerBase
    {
        private readonly IMediator mediator;

        public GoodsReceivedNotesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGoodsRecivedNotes([FromQuery] GetAllGoodsRecivedNotesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{goodsReceivedNoteById}")]
        public async Task<IActionResult> GetById([FromRoute] int goodsReceivedNoteById)
        {

            var request = new GetGoodsReceivedNoteByIdRequest()
            {
                Id = goodsReceivedNoteById
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddGoodsReceivedNote([FromQuery] AddGoodsReceivedNoteRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutGoodsReceivedNotesById([FromQuery] PutGoodsReceivedNotesByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteGoodsReceivedNotesById([FromQuery] DeleteGoodsReceivedNotesByIdRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }


    }
}
