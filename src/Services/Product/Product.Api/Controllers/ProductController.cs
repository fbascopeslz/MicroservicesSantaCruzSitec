using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Service.EventHandlers.Commands;
using Product.Service.Queries.DTOs;
using Product.Service.Queries.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {        
        private readonly ILogger<DefaultController> _logger;
        private readonly IProductQueryService _productQueryService;
        private readonly IMediator _mediator;

        public ProductController(ILogger<DefaultController> logger, IProductQueryService productQueryService, IMediator mediator)
        {
            _logger = logger;
            _productQueryService = productQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetAllAsync()
        {
            return await _productQueryService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetById(int id)
        {
            return await _productQueryService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {            
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateCommand command)
        {
            command.ProductId = id;
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ProductDeleteCommand command = new ProductDeleteCommand()
            {
                ProductId = id
            };
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpPut("updateStock")]
        public async Task<IActionResult> UpdateStock(ProductUpdateStockCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}