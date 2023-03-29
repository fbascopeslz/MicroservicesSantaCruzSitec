using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sale.Persistance.Database.Configuration
{
    public class SaleDetailConfiguration
    {
        public SaleDetailConfiguration(EntityTypeBuilder<Domain.SaleDetail> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.SaleDetailId);            
        }
    }
}