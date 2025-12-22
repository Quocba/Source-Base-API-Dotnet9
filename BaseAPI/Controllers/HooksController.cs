using Application.Features.DeleteHooks;
using Domain.Share.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route(EndpointManage.ApiVersion + "/hooks")]
    public class HooksController(IMediator _mediator) : Controller
    {
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromForm]DeleteHookCommand request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }

    }
}
