using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sale.Persistance.Database.Configuration
{
    public class SaleConfiguration
    {
        public SaleConfiguration(EntityTypeBuilder<Domain.Sale> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.SaleId);            
        }
    }
}