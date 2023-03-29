using MediatR;

namespace Sale.Service.EventHandlers.Commands
{
    public class SaleCreateCommand : INotification
    {
        public IEnumerable<SaleCreateDetail> Items { get; set; } = new List<SaleCreateDetail>();
    }
}