using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HotelLinensController : ApiControllerBase
    {

        public HotelLinensController(IMediator mediator, ILogger<HotelLinensController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in HotelLinens");
           // logger.LogError("An Error Occured");
           
        }


        [HttpGet]
        [Route("")]
        public  Task<IActionResult> GetAllHotelLinnens([FromQuery] GetAllHotelLinensRequest request)
        {
            
            return this.HandleRequest<GetAllHotelLinensRequest, GetAllHotelLinensResponse>(request);

        }

        [HttpGet]
        [Route("{hotelLinenId}")]
        public  Task<IActionResult> GetById([FromRoute] int hotelLinenId)
        {

            var request = new GetHotelLinenByIdRequest()
            {
                HotelLinenId = hotelLinenId
            };

            return this.HandleRequest<GetHotelLinenByIdRequest, GetHotelLinenByIdResponse>(request);

        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddHotelLinen([FromQuery] AddHotelLinenRequest request)
        {
            return this.HandleRequest<AddHotelLinenRequest, AddHotelLinenResponse>(request);

        }

        [HttpPut]
        [Route("")]
        public  Task<IActionResult> PutHotelLinenById([FromQuery] PutHotelLinensByIdRequest request)
        {
            return this.HandleRequest<PutHotelLinensByIdRequest, PutHotelLinensByIdResponse>(request);

        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteHotelLinenById([FromQuery] DeleteHotelLinenByIdRequest request)
        {
           
            return this.HandleRequest<DeleteHotelLinenByIdRequest, DeleteHotelLinenByIdResponse>(request);

        }

    }
}
