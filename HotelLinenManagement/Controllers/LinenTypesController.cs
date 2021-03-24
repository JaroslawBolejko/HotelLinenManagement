using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.LinenTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LinenTypesController : ApiControllerBase
    {
        public LinenTypesController(IMediator mediator, ILogger<LinenTypesController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in Linen Types");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllLinenTypes([FromQuery] GetAllLinenTypesRequest request)
        {
            return this.HandleRequest<GetAllLinenTypesRequest, GetAllLinenTypesResponse>(request);
        }

        [HttpGet]
        [Route("{linenTypeId}")]
        public Task<IActionResult> GetById([FromRoute] int linenTypeId)
        {

            var request = new GetLinenTypeByIdRequest()
            {
                Id = linenTypeId
            };
            return this.HandleRequest<GetLinenTypeByIdRequest, GetLinenTypeByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddLinenType([FromQuery] AddLinenTypeRequest request)
        {
            return this.HandleRequest<AddLinenTypeRequest, AddLinenTypeResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutLinenTypeById([FromQuery] PutLinenTypeByIdRequest request)
        {
            return this.HandleRequest<PutLinenTypeByIdRequest, PutLinenTypeByIdResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteUserById([FromQuery] DeleteLinenTypeByIdRequest request)
        {
            return this.HandleRequest<DeleteLinenTypeByIdRequest, DeleteLinenTypeByIdResponse>(request);
        }
    }
}
