using Microsoft.AspNetCore.Mvc;
using RedisService.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedisService.Enums;

namespace BaseAPI.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRedisService _redisService;

        private static List<Product> _productList = new List<Product>
        {
            new Product { Id = 1, Name = "Apple", Price = 10 },
            new Product { Id = 2, Name = "Banana", Price = 20 },
            new Product { Id = 3, Name = "Orange", Price = 15 },
        };

        public ProductController(IRedisService redisService)
        {
            _redisService = redisService;
        }

       
        [HttpGet("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var cached = await _redisService.GetAsync<List<Product>>(CacheObjectEnum.Products);
            if (cached != null)
                return Ok(new { Source = "Cache", Data = cached });

            var products = _productList.ToList();

            await _redisService.SetAsync(CacheObjectEnum.Products, products, TimeSpan.FromMinutes(10));

            return Ok(new { Source = "MemoryList", Data = products });
        }

    
        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productList.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }


        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product newProduct)
        {
            int newId = _productList.Any() ? _productList.Max(p => p.Id) + 1 : 1;
            newProduct.Id = newId;
            _productList.Add(newProduct);

            await _redisService.RemoveAsync(CacheObjectEnum.Products);

            return Ok(new { Message = "Product added", Product = newProduct });
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updateProduct)
        {
            var product = _productList.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;

            await _redisService.RemoveAsync(CacheObjectEnum.Products);

            return Ok(new { Message = "Product updated", Product = product });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _productList.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            _productList.Remove(product);

            await _redisService.RemoveAsync(CacheObjectEnum.Products);

            return Ok(new { Message = "Product deleted", ProductId = id });
        }
    }
}
