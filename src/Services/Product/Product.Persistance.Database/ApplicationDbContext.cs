using Microsoft.EntityFrameworkCore;
using Product.Persistance.Database.Configuration;

namespace Product.Persistance.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Domain.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Product");

            ModelConfig(modelBuilder);

            Seed(modelBuilder);
        }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductConfiguration(modelBuilder.Entity<Domain.Product>());            
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            Domain.Product product1 = new Domain.Product()
            {
                ProductId = 1,
                Name = "Producto 1",
                Description = "Descripcion Producto 1",
                Price = 13.5m,
                Stock = 5                
            };

            Domain.Product product2 = new Domain.Product()
            {
                ProductId = 2,
                Name = "Producto 2",
                Description = "Descripcion Producto 2",
                Price = 24m,
                Stock = 16
            };

            Domain.Product product3 = new Domain.Product()
            {
                ProductId = 3,
                Name = "Producto 3",
                Description = "Descripcion Producto 3",
                Price = 66m,
                Stock = 8
            };

            modelBuilder.Entity<Domain.Product>().HasData(product1, product2, product3);
        }
    }
}