using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Persistance.Database;
using Product.Service.EventHandlers.Commands;
using static Product.Common.Enums;

namespace Product.Service.EventHandlers
{    
    public class ProductUpdateStockEventHandler : INotificationHandler<ProductUpdateStockCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductUpdateStockEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(ProductUpdateStockCommand command, CancellationToken cancellationToken)
        {            
            var idsProducts = command.Items.Select(x => x.ProductId);

            var products = await _applicationDbContext.Products.Where(x => idsProducts.Contains(x.ProductId)).ToListAsync();            

            foreach (var item in command.Items)
            {
                var product = products.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == ProductStockAction.Substract)
                {
                    //if (product == null || item.Stock > product.Stock)
                    //{                        
                    //    //throw new ProductUpdateStockCommandException($"Product {entry.ProductId} - doens't have enough stock");
                    //}

                    if (product != null && product.Stock >= item.Stock )
                    {
                        product.Stock -= item.Stock;
                    }                                        
                }                
            }

            await _applicationDbContext.SaveChangesAsync();
        }
    }
}