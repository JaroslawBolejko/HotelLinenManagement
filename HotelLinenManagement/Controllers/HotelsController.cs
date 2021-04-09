using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Hotels;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Hotels;
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
    public class HotelsController : ApiControllerBase
    {
        public HotelsController(IMediator mediator, ILogger<HotelsController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in Hotels");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllHotels([FromQuery] GetAllHotelsRequest request)
        {
            return this.HandleRequest<GetAllHotelsRequest, GetAllHotelsResponse>(request);
        }

        [HttpGet]
        [Route("{hotelId}")]
        public Task<IActionResult> GetById([FromRoute] int hotelId)
        {

            var request = new GetHotelByIdRequest()
            {
                Id = hotelId
            };
            return this.HandleRequest<GetHotelByIdRequest, GetHotelByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddHotel([FromQuery] AddHotelRequest request)
        {
            return this.HandleRequest<AddHotelRequest, AddHotelResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutHotelById([FromQuery] PutHotelByIdRequest request)
        {
            return this.HandleRequest<PutHotelByIdRequest, PutHotelByIdResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteHotelById([FromQuery] DeleteHotelByIdRequest request)
        {
            return this.HandleRequest<DeleteHotelByIdRequest, DeleteHotelByIdResponse>(request);
        }

    }
}

