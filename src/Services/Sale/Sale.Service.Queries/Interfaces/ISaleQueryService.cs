namespace Sale.Service.Queries
{
    public interface ISaleQueryService
    {
        public Task<List<SaleDto>> GetAllAsync();
    }
}