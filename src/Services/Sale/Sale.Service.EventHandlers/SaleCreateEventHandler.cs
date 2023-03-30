using MediatR;
using Sale.Persistance.Database;
using Sale.Service.EventHandlers.Commands;
using Sale.Service.Proxies.Product.Commands;
using Sale.Service.Proxies.Product.Interfaces;
using static Sale.Common.Enums;

namespace Sale.Service.EventHandlers
{    
    public class SaleCreateEventHandler : INotificationHandler<SaleCreateCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IProductProxy _productProxy;

        private const decimal IVA = 0.13m;

        public SaleCreateEventHandler(ApplicationDbContext applicationDbContext, IProductProxy productProxy)
        {
            _applicationDbContext = applicationDbContext;
            _productProxy = productProxy;
        }

        public async Task Handle(SaleCreateCommand command, CancellationToken cancellationToken)
        {
            await using (var context = await _applicationDbContext.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var sale = new Domain.Sale();

                    PrepareDetail(sale, command);

                    PrepareHeader(sale, command);

                    await _applicationDbContext.AddAsync(sale, cancellationToken);

                    await _applicationDbContext.SaveChangesAsync(cancellationToken);

                    await UpdateStockAsync(command);

                    await context.CommitAsync(cancellationToken);
                }
                catch (Exception)
                {
                    await context.RollbackAsync(cancellationToken);
                    throw;
                }
            }
        }

        private void PrepareDetail(Domain.Sale sale, SaleCreateCommand command)
        {
            sale.Items = command.Items.Select(x => new Domain.SaleDetail
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.Price,
                Total = x.Price * x.Quantity
            }).ToList();
        }

        private void PrepareHeader(Domain.Sale sale, SaleCreateCommand command)
        {            
            sale.Status = SaleStatus.Pending;                        
            sale.Date = DateTime.UtcNow;
            
            decimal totalWithoutIVA = sale.Items.Sum(x => x.Total);
            sale.Total = totalWithoutIVA + (totalWithoutIVA * IVA);
        }

        private async Task UpdateStockAsync(SaleCreateCommand command) 
        {
            var productUpdateStockCommand = new ProductUpdateStockCommand()
            {
                Items = command.Items.Select(x => new ProductUpdateItem()
                {
                    Action = ProductStockAction.Substract,
                    ProductId = x.ProductId,
                    Stock = x.Quantity
                })
            };

            await _productProxy.UpdateStockAsync(productUpdateStockCommand);
        }
    }
}