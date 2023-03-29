using MediatR;

namespace Product.Service.EventHandlers.Commands
{
    public class ProductDeleteCommand : INotification
    {        
        public int ProductId { get; set; }
    }
}