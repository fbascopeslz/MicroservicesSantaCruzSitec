using Api.Gateway.Models.Sale.Commands;
using Api.Gateway.Models.Sale.DTOs;

namespace Api.Gateway.Proxies.Interfaces
{
    public interface ISaleProxy
    {
        public Task<List<SaleDto>> GetAllAsync();        
        public Task Create(SaleCreateCommand command);
        public Task ChangeSaleStatusDelivered(int id);
    }
}