using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LaundriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public LaundriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllLaundries([FromQuery] GetAllLaundriesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{laundryId}")]
        public async Task<IActionResult> GetById([FromRoute] int laundryId)
        {

            var request = new GetLaundryByIdRequest()
            {
                Id = laundryId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddLaundry([FromQuery] AddLaundryRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutLaundryById([FromQuery] PutLaundryByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteLaundryById([FromQuery] DeleteLaundryByIdRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
