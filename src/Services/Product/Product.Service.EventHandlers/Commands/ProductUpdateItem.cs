using static Product.Common.Enums;

namespace Product.Service.EventHandlers.Commands
{
    public class ProductUpdateItem
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductStockAction Action { get; set; }
    }
}