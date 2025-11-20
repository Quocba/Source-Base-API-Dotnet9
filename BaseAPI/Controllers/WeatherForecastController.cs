using Microsoft.AspNetCore.Mvc;
using RedisService.IService;
using StackExchange.Redis;

namespace BaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IRedisService _redisService, ILogger<WeatherForecastController> _logger) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("set")]
        public async Task<IActionResult> Set([FromQuery] string key, [FromQuery] string value, [FromQuery] int expirySeconds = 300)
        {
            var expiry = TimeSpan.FromSeconds(expirySeconds); 
            await _redisService.SetAsync(key, value, expiry);
            return Ok($"Key '{key}' set successfully with expiry {expirySeconds} seconds.");
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] string key)
        {
            var value = await _redisService.GetAsync(key);
            if (value is null)
                return NotFound($"Key '{key}' not found.");
            return Ok(value);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] string key)
        {
            await _redisService.RemoveAsync(key);
            return Ok($"Key '{key}' deleted successfully.");
        }

    }
}
