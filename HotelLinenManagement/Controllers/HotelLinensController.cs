using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HotelLinensController : ControllerBase
    {
        private readonly IMediator mediator;

        public HotelLinensController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllHotelLinnens([FromQuery] GetAllHotelLinensRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
