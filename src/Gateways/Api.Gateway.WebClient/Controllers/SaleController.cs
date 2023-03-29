using Api.Gateway.Models.Sale.Commands;
using Api.Gateway.Models.Sale.DTOs;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.WebClient.Controllers
{
    [ApiController]
    [Route("sales")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleProxy _saleProxy;

        public SaleController(ISaleProxy saleProxy)
        {
            _saleProxy = saleProxy;
        }

        [HttpGet]
        public async Task<List<SaleDto>> GetAll()
        {
            return await _saleProxy.GetAllAsync();
        }        

        [HttpPost]
        public async Task<IActionResult> Create(SaleCreateCommand command)
        {
            await _saleProxy.Create(command);
            return Ok();
        }

        [HttpPut("changeSaleStatusDelivered/{id}")]
        public async Task<IActionResult> ChangeSaleStatusDelivered(int id)
        {
            await _saleProxy.ChangeSaleStatusDelivered(id);
            return Ok();
        }
    }
}