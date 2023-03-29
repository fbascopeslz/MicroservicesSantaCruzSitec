using Product.Service.Queries.DTOs;

namespace Product.Service.Queries.Interfaces
{
    public interface IProductQueryService
    {
        public Task<List<ProductDto>> GetAllAsync();
        public Task<ProductDto> GetById(int id);        
    }
}