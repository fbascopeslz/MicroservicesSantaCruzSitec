namespace Sale.Service.Proxies.Product.Commands
{
    public class ProductUpdateStockCommand
    {
        public IEnumerable<ProductUpdateItem> Items { get; set; } = new List<ProductUpdateItem>();
    }
}