using Product.Domain;
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
                Name = "Product1",
                Description = "Description",
                Price = 12.94m,
                Stock = 5                
            };

            Domain.Product product2 = new Domain.Product()
            {
                ProductId = 2,
                Name = "Product2",
                Description = "Description",
                Price = 23.47m,
                Stock = 12
            };

            modelBuilder.Entity<Domain.Product>().HasData(product1, product2);
        }
    }
}