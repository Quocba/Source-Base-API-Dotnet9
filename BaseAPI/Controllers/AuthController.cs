using Application.Features.Auth.Command.Login;
using Domain.Share.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route(EndpointManage.ApiVersion + "/auth")]
    public class AuthController(IMediator _mediator) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginCommand request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }
    }
}
