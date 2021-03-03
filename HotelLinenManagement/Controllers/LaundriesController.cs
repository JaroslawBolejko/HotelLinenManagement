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

    }
}
