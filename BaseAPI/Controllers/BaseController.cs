using Application.IService;
using Application.Payload.Request.Products;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/base")]
    public class BaseController(IBaseService _baseSerivce) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
        {
            var response = await _baseSerivce.CreateProduct(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("throw")]
        public IActionResult ThrowException()
        {
            throw new InvalidOperationException("Đây là lỗi test middleware");
        }
    }
}
