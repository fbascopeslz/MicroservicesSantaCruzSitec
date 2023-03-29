using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sale.Service.EventHandlers.Commands;
using Sale.Service.Queries;

namespace Sale.Api.Controllers
{
    [ApiController]
    [Route("sales")]
    public class SaleController : ControllerBase
    {        
        private readonly ISaleQueryService _saleQueryService;
        private readonly IMediator _mediator;

        public SaleController(ISaleQueryService saleQueryService, IMediator mediator)
        {           
            _saleQueryService = saleQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<SaleDto>> GetAllAsync()
        {
            return await _saleQueryService.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaleCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpPut("changeSaleStatusDelivered/{id}")]
        public async Task<IActionResult> ChangeSaleStatusDelivered(int id)
        {
            ChangeSaleStatusDeliveredCommand command = new ChangeSaleStatusDeliveredCommand()
            {
                SaleId = id
            };

            await _mediator.Publish(command);
            return Ok();
        }
    }
}