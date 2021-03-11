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
        [HttpGet]
        [Route("{goodsIssuedNoteById}")]
        public async Task<IActionResult> GetById([FromRoute] int goodsIssuedNoteById)
        {

            var request = new GetGoodsIssuedNoteByIdRequest()
            {
                Id = goodsIssuedNoteById
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddGoodsIssuedNote([FromQuery] AddGoodsIssuedNoteRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutGoodsIssuedNoteById([FromQuery] PutGoodsIssuedNoteByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteGoodsIssuedNoteById([FromQuery] DeleteGoodsIssuedNoteByIdRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }


    }
}
