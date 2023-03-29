using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Persistance.Database;
using Product.Service.EventHandlers.Commands;

namespace Product.Service.EventHandlers
{
    public class ProductUpdateEventHandler : INotificationHandler<ProductUpdateCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;        

        public ProductUpdateEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(ProductUpdateCommand command, CancellationToken cancellationToken)
        {
            var product = await _applicationDbContext.Products.SingleOrDefaultAsync(x => x.ProductId == command.ProductId);

            if (product != null)
            {
                product.Name = command.Name;
                product.Description = command.Description;
                product.Price = command.Price;
                product.Stock = command.Stock;
            }

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}