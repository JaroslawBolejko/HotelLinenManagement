using HotelLinenManagement.ApplicationServices.API.Domain.Requests.GoodsRecivedNotes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
[Route("[controller]")]
public class GoodsReceivedNotesController : ControllerBase
{
    private readonly IMediator mediator;

    public GoodsReceivedNotesController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllGoodsRecivedNotes([FromQuery] GetAllGoodsRecivedNotesRequest request)
    {
        var response = await this.mediator.Send(request);
        return this.Ok(response);
    }


}
}
