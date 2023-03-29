using static Sale.Common.Enums;

namespace Sale.Service.Queries
{
    public class SaleDto
    {
        public int SaleId { get; set; }
        public SaleStatus Status { get; set; }        
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public ICollection<SaleDetailDto> Items { get; set; } = new List<SaleDetailDto>();
    }
}