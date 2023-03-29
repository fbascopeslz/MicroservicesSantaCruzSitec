using Microsoft.EntityFrameworkCore;
using Product.Persistance.Database;
using Product.Service.Queries.DTOs;
using Product.Service.Queries.Interfaces;
using Service.Common.Mapping;

namespace Product.Service.Queries
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductQueryService(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var collection = await _applicationDbContext.Products                                                        
                                                        .OrderByDescending(x => x.ProductId)
                                                        .ToListAsync();            

            return collection.MapTo<List<ProductDto>>();            
        }
    }
}