using Microsoft.EntityFrameworkCore;
using Sale.Persistance.Database;
using Service.Common.Mapping;

namespace Sale.Service.Queries
{
    public class SaleQueryService : ISaleQueryService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SaleQueryService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<SaleDto>> GetAllAsync()
        {
            var collection = await _applicationDbContext.Sales
                                                        .Include(x => x.Items)
                                                        .OrderByDescending(x => x.SaleId)
                                                        .ToListAsync();            

            return collection.MapTo<List<SaleDto>>();
        }
    }
}