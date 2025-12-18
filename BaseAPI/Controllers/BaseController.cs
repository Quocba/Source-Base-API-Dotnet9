using Application.IService;
using Application.Payload.Request.Products;
using Infrastructure.Features.Products.Command.Create;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Products.Command.Edit;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/base")]
    public class BaseController(IBaseService _baseSerivce, IMediator _mediator) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
        {
            var response = await _baseSerivce.CreateProduct(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("{productId}")]
        public async Task<IActionResult> EditProduct(Guid productId, [FromBody] EditProductCommand command)
        {
            var request = new EditProductCommand
            {
                ProductId = productId,
                Sku = command.Sku,
                Name = command.Name,
                Description = command.Description
            };
            var response = await _mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("throw")]
        public IActionResult ThrowException()
        {
            throw new InvalidOperationException("Đây là lỗi test middleware");
        }

        [HttpPost("cqrs")]
        public async Task<IActionResult> CQRS([FromBody] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }
    }
}
