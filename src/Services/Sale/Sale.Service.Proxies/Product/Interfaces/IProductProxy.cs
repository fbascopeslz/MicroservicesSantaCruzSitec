using Sale.Service.Proxies.Product.Commands;

namespace Sale.Service.Proxies.Product.Interfaces
{
    public interface IProductProxy
    {
        public Task UpdateStockAsync(ProductUpdateStockCommand command);
    }
}