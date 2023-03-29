using MediatR;

namespace Sale.Service.EventHandlers.Commands
{
    public class ChangeSaleStatusDeliveredCommand : INotification
    {
        public int SaleId { get; set; }
    }
}