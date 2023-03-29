using MediatR;

namespace Product.Service.EventHandlers.Commands
{
    public class ProductUpdateStockCommand : INotification
    {
        public IEnumerable<ProductUpdateItem> Items { get; set; } = new List<ProductUpdateItem>();
    }
}