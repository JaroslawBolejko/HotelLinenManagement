using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Laundries;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Laundries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LaundriesController : ApiControllerBase
    {
        public LaundriesController(IMediator mediator, ILogger<LaundriesController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in Laundries");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllLaundries([FromQuery] GetAllLaundriesRequest request)
        {
            return this.HandleRequest<GetAllLaundriesRequest, GetAllLaundriesResponse>(request);
        }

        [HttpGet]
        [Route("{laundryId}")]
        public Task<IActionResult> GetById([FromRoute] int laundryId)
        {
            var request = new GetLaundryByIdRequest()
            {
                Id = laundryId
            };
            return this.HandleRequest<GetLaundryByIdRequest, GetLaundryByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddLaundry([FromQuery] AddLaundryRequest request)
        {
            return this.HandleRequest<AddLaundryRequest, AddLaundryResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutLaundryById([FromQuery] PutLaundryByIdRequest request)
        {
            return this.HandleRequest<PutLaundryByIdRequest, PutLaundryByIdResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteLaundryById([FromQuery] DeleteLaundryByIdRequest request)
        {
            return this.HandleRequest<DeleteLaundryByIdRequest, DeleteLaundryByIdResponse>(request);
        }

    }
}
