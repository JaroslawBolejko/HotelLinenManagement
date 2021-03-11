using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HotelsController : ControllerBase
    {
        private readonly IMediator mediator;

        public HotelsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllHotels([FromQuery] GetAllHotelsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{hotelId}")]
        public async Task<IActionResult> GetById([FromRoute] int hotelId)
        {

            var request = new GetHotelByIdRequest()
            {
                Id = hotelId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddHotel([FromQuery] AddHotelRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutHotelById([FromQuery] PutHotelByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteHotelById([FromQuery] DeleteHotelByIdRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}

 