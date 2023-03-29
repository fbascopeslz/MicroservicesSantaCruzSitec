using Microsoft.EntityFrameworkCore;
using Sale.Persistance.Database.Configuration;

namespace Sale.Persistance.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Domain.Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Sale");

            ModelConfig(modelBuilder);

            //Seed(modelBuilder);
        }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            new SaleConfiguration(modelBuilder.Entity<Domain.Sale>());            
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            Domain.Sale sale1 = new Domain.Sale()
            {
                SaleId = 1,                 
            };

            modelBuilder.Entity<Domain.Sale>().HasData(sale1);
        }
    }
}