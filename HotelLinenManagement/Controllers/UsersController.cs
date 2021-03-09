using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromQuery] AddUserRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }


    }
}
