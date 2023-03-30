using Api.Gateway.Models.Product.Commands;
using Api.Gateway.Models.Product.DTOs;

namespace Api.Gateway.WebClient.Proxy
{
    public interface IProductProxy
    {
        public Task<List<ProductDto>> GetAllAsync();
        public Task<ProductDto> GetById(int id);
        public Task Create(ProductCreateCommand command);
        public Task Update(int id, ProductUpdateCommand command);
        public Task Delete(int id);        
    }
}