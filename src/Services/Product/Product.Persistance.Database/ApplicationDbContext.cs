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
        }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductConfiguration(modelBuilder.Entity<Domain.Product>());            
        }
    }
}