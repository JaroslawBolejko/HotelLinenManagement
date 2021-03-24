using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Storerooms;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Storerooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StoreroomsController : ApiControllerBase
    {
        public StoreroomsController(IMediator mediator, ILogger<StoreroomsController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in Storerooms");
        }

        [HttpGet]
        [Route("")]
        public  Task<IActionResult> GetAllStorerooms([FromQuery] GetAllStoreroomsRequest request)
        {
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
            return this.HandleRequest<GetAllStoreroomsRequest, GetAllStoreroomsResponse>(request);
        }

        [HttpGet]
        [Route("{storeroomId}")]
        public Task<IActionResult> GetById([FromRoute] int storeroomId)
        {

            var request = new GetStoreroomByIdRequest()
            {
                StoreroomId = storeroomId
            };
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
            return this.HandleRequest<GetStoreroomByIdRequest, GetStoreroomByIdResponse>(request);

        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddStoreroom([FromQuery] AddStoreroomRequest request)
        {
            return this.HandleRequest<AddStoreroomRequest, AddStoreroomResponse>(request);

            //Miejsce w którym dowiadujemy sie czy reqest jest prawidłowy czy nie i mozemy tu rózne akcje podejmowac
            //if (!this.ModelState.IsValid)
            //{
            //    return this.BadRequest("BAD_REQUEST_Jeb się Psie");
            //}
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public  Task<IActionResult> PutStoreroomById([FromQuery] PutStoreroomsByIdRequest request)
        {
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
            return this.HandleRequest<PutStoreroomsByIdRequest, PutStoreroomsByIdResponse>(request);

        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteStoreroomById([FromQuery] DeleteStoreroomsByIdRequest request)
        {

            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
            return this.HandleRequest<DeleteStoreroomsByIdRequest, DeleteStoreroomsByIdResponse>(request);

        }
    }
}
