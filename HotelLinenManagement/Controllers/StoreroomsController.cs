using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StoreroomsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StoreroomsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStorerooms([FromQuery] GetAllStoreroomsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddStoreroom([FromBody]AddStoreroomRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutHotelLinenById([FromQuery] PutStoreroomsByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteHotelLinenById([FromQuery] DeleteStoreroomsByIdRequest request)
        {
            
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
