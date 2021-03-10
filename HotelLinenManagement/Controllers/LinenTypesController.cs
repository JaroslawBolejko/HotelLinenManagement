using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.LinenTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LinenTypesController : ControllerBase
    {
        private readonly IMediator mediator;

        public LinenTypesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllLinenTypes([FromQuery] GetAllLinenTypesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{linenTypeId}")]
        public async Task<IActionResult> GetById([FromRoute] int linenTypeId)
        {

            var request = new GetLinenTypeByIdRequest()
            {
                Id = linenTypeId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddLinenType([FromQuery] AddLinenTypeRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutLinenTypeById([FromQuery] PutLinenTypeByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteUserById([FromQuery] DeleteLinenTypeByIdRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
