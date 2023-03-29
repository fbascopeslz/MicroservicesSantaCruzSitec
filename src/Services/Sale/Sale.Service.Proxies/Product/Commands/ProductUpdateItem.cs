using static Sale.Common.Enums;

namespace Sale.Service.Proxies.Product.Commands
{
    public class ProductUpdateItem
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductStockAction Action { get; set; }
    }
}