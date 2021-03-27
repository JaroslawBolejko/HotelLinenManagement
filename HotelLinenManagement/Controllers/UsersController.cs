using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ApiControllerBase
    {


        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in Users");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
        {
            return this.HandleRequest<GetAllUsersRequest, GetAllUsersResponse>(request);
        }

        [HttpGet]
        [Route("{userId}")]
        public Task<IActionResult> GetById([FromRoute] int userId)
        {

            var request = new GetUserByIdRequest()
            {
                UserId = userId
            };
            return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);

        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUser([FromQuery] AddUserRequest request)
        {
            
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutUserById([FromQuery] PutUserByIdRequest request)
        {
            return this.HandleRequest<PutUserByIdRequest, PutUserByIdResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteUserById([FromQuery] DeleteUserByIdRequest request)
        {

            return this.HandleRequest<DeleteUserByIdRequest, DeleteUserByIdResponse>(request);
        }

    }
}
