using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Persistance.Database;
using Product.Service.EventHandlers.Commands;

namespace Product.Service.EventHandlers
{
    public class ProductDeleteEventHandler : INotificationHandler<ProductDeleteCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;        

        public ProductDeleteEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(ProductDeleteCommand command, CancellationToken cancellationToken)
        {
            var product = await _applicationDbContext.Products.SingleOrDefaultAsync(x => x.ProductId == command.ProductId);

            if (product != null)
            {
                _applicationDbContext.Remove(product);
            }

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}