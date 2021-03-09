using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens;
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
       
        [HttpGet]
        [Route("{hotelLinenId}")]
        public async Task<IActionResult> GetById([FromRoute] int hotelLinenId)
        {

            var request = new GetHotelLinenByIdRequest()
            {
                HotelLinenId = hotelLinenId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddHotelLinen([FromQuery] AddHotelLinenRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult>PutHotelLinenById([FromQuery] PutHotelLinensByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("hotelLinenId")]
        public async Task<IActionResult> DeleteHotelLinenById([FromRoute] int hotelLinenId)
        {
            var request = new DeleteHotelLinenByIdRequest
            {
                HotelLinenId = hotelLinenId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
