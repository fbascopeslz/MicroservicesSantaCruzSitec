using MediatR;
using Microsoft.EntityFrameworkCore;
using Sale.Persistance.Database;
using Sale.Service.EventHandlers.Commands;
using static Sale.Common.Enums;

namespace Sale.Service.EventHandlers
{    
    public class ChangeSaleStatusDeliveredEventHandler : INotificationHandler<ChangeSaleStatusDeliveredCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;        

        public ChangeSaleStatusDeliveredEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;            
        }

        public async Task Handle(ChangeSaleStatusDeliveredCommand command, CancellationToken cancellationToken)
        {
            var sale = await _applicationDbContext.Sales.SingleOrDefaultAsync(x => x.SaleId == command.SaleId);

            if (sale != null)
            {
                sale.Status = SaleStatus.Delivered;                
            }

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }       
    }
}