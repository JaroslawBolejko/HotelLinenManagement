using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsIssuedNotes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.GoodsIssuedNotes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GoodsIssuedNotesController : ApiControllerBase
    {
        public GoodsIssuedNotesController(IMediator mediator, ILogger<GoodsIssuedNotesController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in GoodsIssuedNotes");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllGoodsIssuedNotes([FromQuery] GetAllGoodsIssuedNotesRequest request)
        {
            return this.HandleRequest<GetAllGoodsIssuedNotesRequest, GetAllGoodsIssuedNotesResponse>(request);
        }
        [HttpGet]
        [Route("{goodsIssuedNoteById}")]
        public  Task<IActionResult> GetById([FromRoute] int goodsIssuedNoteById)
        {

            var request = new GetGoodsIssuedNoteByIdRequest()
            {
                Id = goodsIssuedNoteById
            };
            return this.HandleRequest<GetGoodsIssuedNoteByIdRequest, GetGoodsIssuedNoteByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddGoodsIssuedNote([FromQuery] AddGoodsIssuedNoteRequest request)
        {
            return this.HandleRequest<AddGoodsIssuedNoteRequest, AddGoodsIssuedNoteResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutGoodsIssuedNoteById([FromQuery] PutGoodsIssuedNoteByIdRequest request)
        {
            return this.HandleRequest<PutGoodsIssuedNoteByIdRequest, PutGoodsIssuedNoteByIdResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteGoodsIssuedNoteById([FromQuery] DeleteGoodsIssuedNoteByIdRequest request)
        {
            return this.HandleRequest<DeleteGoodsIssuedNoteByIdRequest, DeleteGoodsIssuedNoteByIdResponse>(request);
        }

    }
}
