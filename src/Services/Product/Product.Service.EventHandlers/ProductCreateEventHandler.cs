using MediatR;
using Product.Persistance.Database;
using Product.Service.EventHandlers.Commands;

namespace Product.Service.EventHandlers
{
    public class ProductCreateEventHandler : INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;        

        public ProductCreateEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            Domain.Product product = new Domain.Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                Stock = command.Stock,
            };

            await _applicationDbContext.AddAsync(product);

            await _applicationDbContext.SaveChangesAsync();
        }
    }
}