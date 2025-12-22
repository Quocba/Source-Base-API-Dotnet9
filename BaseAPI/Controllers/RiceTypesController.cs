using Application.Features.RiceType.Command.Create;
using Application.Features.RiceType.Command.Edit;
using Application.Features.RiceType.Queries.GetRiceTypes;
using Application.Payload.Base.Paginate;
using Application.Payload.Response.RiceTypes;
using Domain.Payload.Base;
using Domain.Share.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route(EndpointManage.ApiVersion + "/rice-types")]
    public class RiceTypesController(IMediator _mediator) : Controller
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRiceType([FromBody] CreateRiceTypeCommand request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("{Id}")]
        [Authorize]
        public async Task<IActionResult> EditRiceType(Guid Id, [FromBody] EditRiceTypeCommand request)
        {
            request.Id = Id;
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRiceTypes([FromQuery] GetRiceTypesQuery request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }
    }
}
