using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsRecivedNotes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GoodsReceivedNotesController : ApiControllerBase
    {
        public GoodsReceivedNotesController(IMediator mediator, ILogger<GoodsReceivedNotesController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in GoodsReceivedNotes");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllGoodsRecivedNotes([FromQuery] GetAllGoodsRecivedNotesRequest request)
        {
            return this.HandleRequest<GetAllGoodsRecivedNotesRequest, GetAllGoodsRecivedNotesResponse>(request);
        }

        [HttpGet]
        [Route("{goodsReceivedNoteById}")]
        public Task<IActionResult> GetById([FromRoute] int goodsReceivedNoteById)
        {

            var request = new GetGoodsReceivedNoteByIdRequest()
            {
                Id = goodsReceivedNoteById
            };
            return this.HandleRequest<GetGoodsReceivedNoteByIdRequest, GetGoodsReceivedNoteByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddGoodsReceivedNote([FromQuery] AddGoodsReceivedNoteRequest request)
        {
            return this.HandleRequest<AddGoodsReceivedNoteRequest, AddGoodsReceivedNoteResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutGoodsReceivedNotesById([FromQuery] PutGoodsReceivedNotesByIdRequest request)
        {
            return this.HandleRequest<PutGoodsReceivedNotesByIdRequest, PutGoodsReceivedNotesByIdResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteGoodsReceivedNotesById([FromQuery] DeleteGoodsReceivedNotesByIdRequest request)
        {
            return this.HandleRequest<DeleteGoodsReceivedNotesByIdRequest, DeleteGoodsReceivedNotesByIdResponse>(request);
        }


    }
}
