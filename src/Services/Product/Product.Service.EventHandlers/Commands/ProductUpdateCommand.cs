using MediatR;

namespace Product.Service.EventHandlers.Commands
{
    public class ProductUpdateCommand : INotification
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}