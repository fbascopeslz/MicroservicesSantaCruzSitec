using Api.Gateway.Models.Product.Commands;
using Api.Gateway.Models.Product.DTOs;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.WebClient.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductProxy _productProxy;

        public ProductController(IProductProxy productProxy)
        {
            _productProxy = productProxy;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetAll()
        {
            return await _productProxy.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetById(int id)
        {
            return await _productProxy.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            await _productProxy.Create(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateCommand command)
        {
            await _productProxy.Update(id, command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productProxy.Delete(id);
            return Ok();
        }
    }
}